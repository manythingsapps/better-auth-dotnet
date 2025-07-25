namespace BetterAuth.DTOs;

internal struct SessionToken
{
    public string Token { get; set; }
    public long ExpiresAt { get; set; }
}
