namespace BetterAuth.Configurations;

public sealed class EmailAndPasswordOptions
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
    /// @default 70
    /// </summary>
    public int? MaxPasswordLength { get; set; } = 70;

    /// <summary>
    /// The minimum length of the password.
    /// 
    /// @default 8
    /// </summary>
    public int? MinPasswordLength { get; set; } = 8;

    /// <summary>
    /// Number of seconds the reset password token is valid for.
    /// 
    /// @default 1 hour (60 * 60)
    /// </summary>
    public int? ResetPasswordTokenExpiresIn { get; set; } = (60 * 60);

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
