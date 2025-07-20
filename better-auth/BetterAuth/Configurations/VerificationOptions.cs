namespace BetterAuth.Configurations;

internal sealed class VerificationOptions
{
    /// <summary>
    /// Change the modelName of the verification table
    /// </summary>
    public string? ModelName { get; set; }

    /// <summary>
    /// disable cleaning up expired values when a verification value is
    /// fetched
    /// </summary>
    public bool? DisableCleanup { get; set; }
}
