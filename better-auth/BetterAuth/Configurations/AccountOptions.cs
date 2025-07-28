namespace BetterAuth.Configurations;

public sealed class AccountOptions
{
    /// <summary>
    /// When enabled (true), the user account data (accessToken, idToken, refreshToken, etc.)
	/// will be updated on sign in with the latest data from the provider.
    ///
    /// @default true
    /// </summary>
    public bool? UpdateAccountOnSignIn { get; set; } = true;

    /// <summary>
    /// Configuration for account linking.
    /// </summary>
    public AccountLinkingOptions? AccountLinking { get; set; }

    /// <summary>
    /// Encrypt OAuth tokens
    /// 
    /// By default, OAuth tokens (access tokens, refresh tokens, ID tokens) are stored in plain text in the database.
    /// This poses a security risk if your database is compromised, as attackers could gain access to user accounts
    /// on external services.
    /// 
    /// When enabled, tokens are encrypted using AES-256-GCM before storage, providing protection against:
    /// - Database breaches and unauthorized access to raw token data
    /// - Internal threats from database administrators or compromised credentials
    /// - Token exposure in database backups and logs
    /// @default false
    /// </summary>
    public bool? EncryptOAuthTokens { get; set; } = false;
}

public sealed class AccountLinkingOptions
{
    private string[]? _trustedProviders;

    /// <summary>
    /// Enable account linking
    /// 
    /// @default true
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// List of trusted providers
    /// </summary>
    public string[]? TrustedProviders 
    {
        get => _trustedProviders;
        set => _trustedProviders = [..Enum.GetNames(typeof(SocialProvidersList)), "email-password"];
    }

    /// <summary>
    /// If enabled (true), this will allow users to manually linking accounts with different email addresses than the main user.
	///
	/// @default false
	///
	/// ⚠️ Warning: enabling this might lead to account takeovers, so proceed with caution.
    /// </summary>
    public bool? AllowDifferentEmails { get; set; } = false;

    /// <summary>
    /// If enabled (true), this will allow users to unlink all accounts.
	///
	/// @default false
    /// </summary>
    public bool? AllowUnlinkingAll { get; set; } = false;

    /// <summary>
    /// If enabled (true), this will update the user information based on the newly linked account
    /// 
    /// @default false
    /// </summary>
    public bool? UpdateUserInfoOnLink { get; set; } = false;
}