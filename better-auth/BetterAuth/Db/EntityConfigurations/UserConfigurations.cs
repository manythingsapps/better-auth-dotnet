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
public partial class UserConfigurations<T> : IEntityTypeConfiguration<User<T>>
{
    public virtual void Configure(EntityTypeBuilder<User<T>> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Email)
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
/// Default User configuration with string as the ID type.
/// </summary>
public partial class UserConfigurations : UserConfigurations<string>
{
    public override void Configure(EntityTypeBuilder<User<string>> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Id)
            .HasValueGenerator<GuidToStringGenerator>()
            .ValueGeneratedOnAdd();
    }
}