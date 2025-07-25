using BetterAuth.Configurations;

namespace BetterAuth.DTOs;

internal sealed class CookieCreationResponse
{
    public string Name { get; set; } = default!;
    public BetterAuthCookie Attributes { get; set; } = default!;
}
