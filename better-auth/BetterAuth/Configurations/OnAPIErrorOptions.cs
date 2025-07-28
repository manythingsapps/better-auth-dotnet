namespace BetterAuth.Configurations;

public sealed class OnAPIErrorOptions
{
    /// <summary>
    /// Throw an error on API error
    /// 
    /// @default false
    /// </summary>
    public bool? Throw { get; set; } = false;

    /// <summary>
    /// The URL to redirect to on error
    /// 
    /// When errorURL is provided, the error will be added to the URL as a query parameter
    /// and the user will be redirected to the errorURL.
    /// 
    /// @default - "/api/auth/error"
    /// </summary>
    public string? ErrorURL { get; set; } = "/api/auth/error";
}
