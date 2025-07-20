namespace BetterAuth.Configurations;

internal sealed class BetterAuthOptions
{
    /// <summary>
    /// The name of the application
    /// BetterAuthOptions__APP_NAME
    /// </summary>
    public string? AppName { get; set; } = "Better Auth";

    /// <summary>
    /// Base URL for the Better Auth. This is typically the
	/// root URL where your application server is hosted.
    /// If not explicitly set,
	/// the system will check the following environment variable:
    /// BetterAuthOptions__BETTER_AUTH_URL
    /// </summary>
    public string? BaseURL { get; set; }

    /// <summary>
    /// Base path for the Better Auth. This is typically
    /// the path where the Better Auth routes are mounted.
    /// 
    /// @default "/api/auth"
    /// </summary>
    public string? BasePath { get; set; } = "/api/auth";

    /// <summary>
    /// The secret to use for encryption,
	/// signing and hashing.
    ///
    ///
    /// By default Better Auth will look for
	/// the following environment variables:
	/// BetterAuthOptions__BETTER_AUTH_SECRET,
	/// BetterAuthOptions__AUTH_SECRET
    /// If none of these environment
	/// variables are set,
	/// it will default to
    /// "better-auth-secret-123456789".
	///
	/// on production if it's not set
	/// it will throw an error.
	///
	/// you can generate a good secret
	/// using the following command:
    ///
    /// @example
    ///
    /// ```bash
    /// openssl rand -base64 32
    ///
    /// ```
    /// </summary>
    public string? Secret { get; set; }

    /// <summary>
    /// Database connection string.
    /// </summary>
    public string? Database { get; set; }

    /// <summary>
    /// Secondary storage connection string.
    /// This is used to store session and rate limit data.
    /// </summary>
    public string? SecondaryStorage { get; set; }

    /// <summary>
    /// Email verification configuration
    /// </summary>
    public bool? EmailVerification { get; set; }

    /// <summary>
    /// Email and password authentication
    /// </summary>
    public EmailAndPasswordOptions? EmailAndPassword { get; set; }

    /// <summary>
    /// list of social providers
    /// </summary>
    public SocialProvidersOptions? SocialProviders { get; set; }

    /// <summary>
    /// User configuration
    /// </summary>
    public UserOptions? User { get; set; }

    /// <summary>
    /// Session configuration
    /// </summary>
    public SessionOptions? Session { get; set; }

    /// <summary>
    /// Account configuration
    /// </summary>
    public AccountOptions? Account { get; set; }

    /// <summary>
    /// Verification configuration
    /// </summary>
    public VerificationOptions? Verification { get; set; }

    /// <summary>
    /// List of trusted origins.
    /// </summary>
    public string[]? TrustedOrigins { get; set; }
}