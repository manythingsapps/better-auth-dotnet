namespace BetterAuth.Api.Responses;

public sealed class BetterAuthError : Exception
{
    public string Type { get; } = default!;

    public BetterAuthError(string type, string message)
        : base(message)
    {
        Type = type;
    }
}
