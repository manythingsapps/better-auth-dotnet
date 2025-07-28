namespace BetterAuth.Configurations;

public sealed class VerificationOptions
{
    /// <summary>
    /// disable cleaning up expired values when a verification value is
    /// fetched
    /// </summary>
    public bool? DisableCleanup { get; set; }
}
