using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterAuth.Db.Repositories;

internal sealed class Repository : IRepository
{
    private readonly BetterAuthDbContext _context;

    public Repository(BetterAuthDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email, CancellationToken ct)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, ct);
    }

    public async Task CreateUser(User user, CancellationToken ct)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(ct);
    }

    public async Task LinkAccount(Account account, CancellationToken ct)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<List<Session>> GetSessions(string userId, CancellationToken ct)
    {
        return await _context.Sessions
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .ToListAsync(ct);
    }
}
