using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

[Table("Accounts")]
public partial class Account : BaseEntity
{
    public string ProviderId { get; set; } = default!;
    public string AccountId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? IdToken { get; set; }
    public DateTime? AccessTokenExpiresAt { get; set; }
    public DateTime? RefreshTokenExpiresAt { get; set; }
    public string? Scope { get; set; }
    public string? Password { get; set; }

    public virtual User User { get; set; } = default!;
}
