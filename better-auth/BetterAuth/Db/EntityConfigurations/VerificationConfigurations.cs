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
public partial class VerificationConfigurations<T> : IEntityTypeConfiguration<Verification<T>>
{
    public virtual void Configure(EntityTypeBuilder<Verification<T>> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder.Property(s => s.Identifier)
            .IsRequired();
        
        builder.Property(s => s.Value)
            .IsRequired();

        builder.Property(s => s.ExpiresAt)
            .IsRequired();

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
/// Default Verification configuration with string as the ID type.
/// </summary>
public partial class VerificationConfigurations : VerificationConfigurations<string>
{
    public override void Configure(EntityTypeBuilder<Verification<string>> builder)
    {
        base.Configure(builder);
        builder
            .Property(x => x.Id)
            .HasValueGenerator<GuidToStringGenerator>()
            .ValueGeneratedOnAdd();
    }
}