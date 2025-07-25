using BetterAuth.Api.Requests;
using BetterAuth.Api.Responses;

namespace BetterAuth.Api;

public interface IBetterAuthService
{
    Task<SignupResponse> HandleSignup(SignupRequest request, CancellationToken ct = default!);
}
