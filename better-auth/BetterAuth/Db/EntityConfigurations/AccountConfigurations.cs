using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetterAuth.Db.EntityConfigurations;

/// <summary>
/// Configuration for the generic Account entity.
/// 
/// inherit to provide additional configuration.
/// </summary>
/// <typeparam name="T">Default string</typeparam>
public partial class AccountConfigurations<T> : IEntityTypeConfiguration<Account<T>>
{
    public virtual void Configure(EntityTypeBuilder<Account<T>> builder)
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
            .IsRequired()
            .HasValueGenerator<DateTimeUtcGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(a => a.UpdatedAt)
            .IsRequired()
            .HasValueGenerator<DateTimeUtcGenerator>()
            .ValueGeneratedOnAddOrUpdate();
    }
}

/// <summary>
/// Default Account configuration with string as the ID type.
/// </summary>
public partial class AccountConfigurations : AccountConfigurations<string>
{
    public override void Configure(EntityTypeBuilder<Account<string>> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Id)
            .HasValueGenerator<GuidToStringGenerator>()
            .ValueGeneratedOnAdd();
    }
}
