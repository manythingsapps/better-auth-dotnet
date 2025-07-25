using System.ComponentModel.DataAnnotations;

namespace BetterAuth.Configurations;

internal sealed class EmailAndPasswordOptions
{
    /// <summary>
    /// Enable email and password authentication
    /// 
    /// @default false
    /// </summary>
    public bool? Enabled { get; set; } = false;

    /// <summary>
    /// Disable email and password sign up
    /// 
    /// @default false
    /// </summary>
    public bool? DisableSignUp { get; set; } = false;

    /// <summary>
    /// Require email verification before a session
    /// can be created for the user.
    /// 
    /// if the user is not verified, the user will not be able to sign in
    /// and on sign in attempts, the user will be prompted to verify their email.
    /// </summary>
    public bool? RequireEmailVerification { get; set; }

    /// <summary>
    /// The maximum length of the password.
    /// 
    /// @default 72
    /// </summary>
    [Range(1, 72)]
    public int? MaxPasswordLength { get; set; } = 72;

    /// <summary>
    /// The minimum length of the password.
    /// 
    /// @default 8
    /// </summary>
    public int? MinPasswordLength { get; set; } = 8;

    /// <summary>
    /// Automatically sign in the user after sign up
    /// 
    /// @default true
    /// </summary>
    public bool? AutoSignIn { get; set; } = true;

    /// <summary>
    /// Whether to revoke all other sessions when resetting password
    /// @default false
    /// </summary>
    public bool? RevokeSessionsOnPasswordReset { get; set; } = false;
}
