using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

/// <summary>
/// Provide additional properties by inheriting.
/// </summary>
[Table("Sessions")]
public partial class Session<T>
{
    public T Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public string Token { get; set; } = default!;
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User<T> User { get; set; } = default!;
}

/// <summary>
/// Base Session class with string as the ID type.
/// </summary>
public partial class Session : Session<string>
{
    public override User<string> User { get; set; } = default!;
}