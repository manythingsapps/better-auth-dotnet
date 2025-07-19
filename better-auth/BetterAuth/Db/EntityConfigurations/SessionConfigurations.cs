using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetterAuth.Db.EntityConfigurations;

public partial class SessionConfigurations : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
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
            .IsRequired();
        builder.Property(a => a.UpdatedAt)
            .IsRequired();
    }
}
