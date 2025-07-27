using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

/// <summary>
/// Provide additional properties by inheriting.
/// </summary>
[Table("Accounts")]
public partial class Account<T>
{
    public T Id { get; set; } = default!;
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
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User<T> User { get; set; } = default!;
}

/// <summary>
/// Base Account class with string as the ID type.
/// </summary>
public partial class Account : Account<string>
{
    public override User<string> User { get; set; } = default!;
}