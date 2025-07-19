using BetterAuth.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetterAuth.Db.EntityConfigurations;

public partial class VerificationConfigurations : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
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
            .IsRequired();
        builder.Property(a => a.UpdatedAt)
            .IsRequired();
    }
}
