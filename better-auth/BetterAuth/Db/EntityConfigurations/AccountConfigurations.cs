using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetterAuth.Db.EntityConfigurations;

public partial class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder.Property(a => a.AccountId)
            .IsRequired();

        builder.Property(a => a.ProviderId)
            .IsRequired();

        builder.Property(a => a.UserId)
            .IsRequired();
        builder.HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.CreatedAt)
            .IsRequired();
        builder.Property(a => a.UpdatedAt)
            .IsRequired();
    }
}
