using BetterAuth.Api.Requests;

namespace BetterAuth.Api;

public class BetterAuthService : IBetterAuthService
{
    public Task HandleSignup(SignupRequest request)
    {
        return Task.CompletedTask;
    }
}
