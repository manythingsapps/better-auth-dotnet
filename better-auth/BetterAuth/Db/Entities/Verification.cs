using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

[Table("Verifications")]
public partial class Verification : BaseEntity
{
    public string Value { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public string Identifier { get; set; } = default!;
}
