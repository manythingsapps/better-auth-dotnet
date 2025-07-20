namespace BetterAuth.Db.Entities;

public partial class Session : BaseEntity
{
    public string UserId { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public string Token { get; set; } = default!;
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }

    public virtual User User { get; set; } = default!;
}
