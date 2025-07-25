using BetterAuth.Db.Entities;

namespace BetterAuth.Db.Repositories;

internal interface IRepository
{
    Task<User?> GetUserByEmail(string email, CancellationToken ct);

    Task CreateUser(User user, CancellationToken ct);

    Task LinkAccount(Account account, CancellationToken ct);

    Task<List<Session>> GetSessions(string userId, CancellationToken ct);

    Task CreateSession(Session session, CancellationToken ct);
}
