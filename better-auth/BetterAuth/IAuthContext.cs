using BetterAuth.Db.Entities;

namespace BetterAuth;
public interface IAuthContext
{
    Task SendVerificationEmail(User user, string url, string token);
    Task<Session> CreateSession(string userId, bool dontRememberMe, CancellationToken ct = default!);
}
