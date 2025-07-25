using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterAuth.Db;

internal class BetterAuthDbContext : DbContext
{
    public BetterAuthDbContext(
        DbContextOptions<BetterAuthDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    internal DbSet<User> Users { get; set; }
    internal DbSet<Account> Accounts { get; set; }
    internal DbSet<Session> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BetterAuthDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
