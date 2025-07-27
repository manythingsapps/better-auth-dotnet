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
public partial class SessionConfigurations<T> : IEntityTypeConfiguration<Session<T>>
{
    public virtual void Configure(EntityTypeBuilder<Session<T>> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder.Property(s => s.ExpiresAt)
            .IsRequired();

        builder.Property(s => s.Token)
            .IsRequired();
        builder.HasIndex(s => s.Token)
            .IsUnique();

        builder.Property(s => s.UserId)
            .IsRequired();
        builder.HasOne(s => s.User)
            .WithOne(u => u.Session)
            .HasForeignKey<Session>(s => s.UserId)
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
/// Default Session configuration with string as the ID type.
/// </summary>
public partial class SessionConfigurations : SessionConfigurations<string>
{
    public override void Configure(EntityTypeBuilder<Session<string>> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Id)
            .HasValueGenerator<GuidToStringGenerator>()
            .ValueGeneratedOnAdd();
    }
}
