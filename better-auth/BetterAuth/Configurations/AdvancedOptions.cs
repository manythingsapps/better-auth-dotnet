namespace BetterAuth.Configurations;

internal sealed class AdvancedOptions
{
    /// <summary>
    /// Ip address configuration
    /// </summary>
    public IpAddressOptions? IpAddress { get; set; }

    /// <summary>
    /// Use secure cookies
    /// 
    /// @default false
    /// </summary>
    public bool? UseSecureCookies { get; set; } = false;

    /// <summary>
    /// Disable trusted origins check
    /// 
    /// ⚠︎ This is a security risk and it may expose your application to CSRF attacks
    /// </summary>
    public bool? DisableCSRFCheck { get; set; }

    /// <summary>
    /// Configure cookies to be cross subdomains
    /// </summary>
    public CrossSubDomainCookiesOptions? CrossSubDomainCookies { get; set; }

    /// <summary>
    /// Prefix for cookies. If a cookie name is provided
    /// in cookies config, this will be overridden.
    /// 
    /// @default
    /// ```txt
    /// "appName" -> which defaults to "better-auth"
    /// ```
    /// </summary>
    public string? CookiePrefix { get; set; }
}

internal sealed class IpAddressOptions
{
    /// <summary>
    /// List of headers to use for ip address
    ///
    /// Ip address is used for rate limiting and session tracking
    ///   
    /// @example["x-client-ip", "x-forwarded-for", "cf-connecting-ip"]
    /// </summary>
    public string[]? IpAddressHeaders { get; set; }

    /// <summary>
    /// Disable ip tracking
    /// 
    /// ⚠︎ This is a security risk and it may expose your application to abuse
    /// </summary>
    public bool? DisableIpTracking { get; set; }
}

internal sealed class CrossSubDomainCookiesOptions
{
    /// <summary>
    /// Enable cross subdomain cookies
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Additional cookies to be shared across subdomains
    /// </summary>
    public string[]? AdditionalCookies { get; set; }

    /// <summary>
    /// The domain to use for the cookies
    /// 
    /// By default, the domain will be the root
    /// domain from the base URL.
    /// </summary>
    public string? Domain { get; set; }
}