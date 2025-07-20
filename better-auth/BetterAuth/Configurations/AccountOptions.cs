using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BetterAuth.Configurations;

internal sealed class AccountOptions
{
    /// <summary>
    /// The model name for the account. Defaults to "account".
    /// </summary>
    public string? ModelName { get; set; } = "account";

    /// <summary>
    /// When enabled (true), the user account data (accessToken, idToken, refreshToken, etc.)
	/// will be updated on sign in with the latest data from the provider.
    ///
    /// @default true
    /// </summary>
    public bool? UpdateAccountOnSignIn { get; set; } = true;


}

internal sealed class AccountLinking
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