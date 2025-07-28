using BetterAuth.Db.Entities;
using BetterAuth.Db.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BetterAuth.Db;

public partial class BetterAuthDbContext : DbContext
{
    public BetterAuthDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new AccountConfigurations());
        modelBuilder.ApplyConfiguration(new SessionConfigurations());
        modelBuilder.ApplyConfiguration(new VerificationConfigurations());
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Session> Sessions { get; set; }
    public virtual DbSet<Verification> Verifications { get; set; }
}
