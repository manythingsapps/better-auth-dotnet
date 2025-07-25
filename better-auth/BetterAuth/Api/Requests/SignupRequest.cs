using FluentValidation;

namespace BetterAuth.Api.Requests;

public partial class SignupRequest
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? Image { get; set; }
    public string? CallbackURL { get; set; }
    public bool? rememberMe { get; set; }
}

public class SignupRequestValidator : AbstractValidator<SignupRequest>
{
    public SignupRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email is required");
    }
}