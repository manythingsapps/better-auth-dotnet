using BetterAuth.Api.Requests;
using BetterAuth.Api.Responses;
using BetterAuth.Configurations;
using BetterAuth.Constants;
using BetterAuth.Db.Entities;
using BetterAuth.Db.Repositories;
using BetterAuth.Services;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BetterAuth.Api;

public partial class BetterAuthService : IBetterAuthService
{
    private readonly BetterAuthOptions _betterAuthOptions;
    private readonly IRepository _repository;
    private readonly IAuthContext _authContext;
    private readonly IValidator<SignupRequest> _signupRequestValidator;
    private readonly ILogger<BetterAuthService> _logger;

    internal BetterAuthService(
        IRepository repository,
        IAuthContext authContext,
        IValidator<SignupRequest> signupRequestValidator,
        IOptions<BetterAuthOptions> betterAuthOptions,
        ILogger<BetterAuthService> logger)
    {
        _betterAuthOptions = betterAuthOptions.Value;
        _repository = repository;
        _authContext = authContext;
        _signupRequestValidator = signupRequestValidator;
        _logger = logger;
    }

    public async Task<SignupResponse> HandleSignup(SignupRequest request, CancellationToken ct = default!)
    {
        if (_betterAuthOptions.EmailAndPassword?.Enabled == false ||
            _betterAuthOptions.EmailAndPassword?.DisableSignUp == true)
        {
            throw new BetterAuthError(
                "BAD_REQUEST",
                "Email and password sign up is not enabled"
            );
        }

        var validationResult = _signupRequestValidator.Validate(request);
        if (!validationResult.IsValid && validationResult.Errors.Any(x => x.PropertyName == nameof(SignupRequest.Email)))
        {
            throw new BetterAuthError(
                "BAD_REQUEST",
                BaseErrorCodes.INVALID_EMAIL
            );
        }

        if (_betterAuthOptions.EmailAndPassword?.MinPasswordLength != null &&
            request.Password.Length < _betterAuthOptions.EmailAndPassword?.MinPasswordLength)
        {
            throw new BetterAuthError(
                "BAD_REQUEST",
                BaseErrorCodes.PASSWORD_TOO_SHORT
            );
        }

        if (_betterAuthOptions.EmailAndPassword?.MaxPasswordLength != null &&
            request.Password.Length > _betterAuthOptions.EmailAndPassword?.MaxPasswordLength)
        {
            throw new BetterAuthError(
                "BAD_REQUEST",
                BaseErrorCodes.PASSWORD_TOO_LONG
            );
        }

        var existingUser = await _repository.GetUserByEmail(request.Email.ToLowerInvariant(), ct);
        if (existingUser is not null)
        {
            throw new BetterAuthError(
                "UNPROCESSABLE_ENTITY",
                BaseErrorCodes.USER_ALREADY_EXISTS
            );
        }

        /**
		* Hash the password
		*
		* This is done prior to creating the user
		* to ensure that any plugin that
		* may break the hashing should break
		* before the user is created.
		*/
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Email = request.Email,
            Name = request.Name,
            Image = request.Image,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        try
        {
            await _repository.CreateUser(user, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user with email {Email}", request.Email);

            throw new BetterAuthError(
                "UNPROCESSABLE_ENTITY",
                BaseErrorCodes.FAILED_TO_CREATE_USER
            );
        }

        var account = new Account
        {
            UserId = user.Id,
            ProviderId = OtherConstants.DefaultProvider,
            AccountId = user.Id,
            Password = hash,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await _repository.LinkAccount(account, ct);

        if (_betterAuthOptions.EmailVerification?.SendOnSignup == true ||
            _betterAuthOptions.EmailAndPassword?.RequireEmailVerification == true)
        {
            var token = TokenService.SignJWT(new
            {
                Email = user.Email,
            }, _betterAuthOptions.Secret!, _betterAuthOptions.EmailVerification!.ExpiresIn);

            var callBackURL = !string.IsNullOrWhiteSpace(request.CallbackURL) ? request.CallbackURL : "/";
            var url = $"{_betterAuthOptions.BaseURL}/verify-email?token=${token}&callbackURL =${callBackURL}";

            await _authContext.SendVerificationEmail(user, url, token);
        }

        if (_betterAuthOptions.EmailAndPassword?.AutoSignIn == false ||
            _betterAuthOptions.EmailAndPassword?.RequireEmailVerification == true)
        {
            return new SignupResponse {
                User = user,
                Token = null
            };
        }

        var session = await _authContext.CreateSession(user.Id, false, ct);
        if(session is null)
        {
            throw new BetterAuthError(
                "BAD_REQUEST",
                BaseErrorCodes.FAILED_TO_CREATE_SESSION
            );
        }
    }
}
