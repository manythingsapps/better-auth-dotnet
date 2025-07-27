namespace BetterAuth.Configurations;

public sealed class EmailVerificationOptions
{
    /// <summary>
    /// Send a verification email automatically after sign up
    /// 
    /// @default false
    /// </summary>
    public bool? SendOnSignUp { get; set; } = false;

    /// <summary>
    /// Send a verification email automatically after sign in
    /// when the user's email is not verified
    /// 
    /// @default false
    /// </summary>
    public bool? SendOnSignIn { get; set; } = false;

    /// <summary>
    /// Auto signin the user after they verify their email
    /// </summary>
    public bool? AutoSignInAfterVerification { get; set; }

    /// <summary>
    /// Number of seconds the verification token is valid for.
    /// 
    /// @default 3600 seconds (1 hour)
    /// </summary>
    public int ExpiresIn { get; set; } = 3600;
}
