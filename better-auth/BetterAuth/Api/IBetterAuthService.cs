using BetterAuth.Api.Requests;

namespace BetterAuth.Api;

public interface IBetterAuthService
{
    Task HandleSignup(SignupRequest request);
}
