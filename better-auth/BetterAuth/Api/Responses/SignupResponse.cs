using BetterAuth.Db.Entities;

namespace BetterAuth.Api.Responses;

public sealed class SignupResponse
{
    public string? Token { get; set; }
    public User User { get; set; } = default!;
}
