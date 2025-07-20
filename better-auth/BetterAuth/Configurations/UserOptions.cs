namespace BetterAuth.Configurations;

internal sealed class UserOptions
{
    /// <summary>
    /// The model name for the user. Defaults to "user".
    /// </summary>
    public string? ModelName { get; set; } = "user";

    /// <summary>
    /// Changing email configuration
    /// </summary>
    public ChangeEmail? ChangeEmail { get; set; }

    /// <summary>
    /// User deletion configuration
    /// </summary>
    public DeleteUser? DeleteUser { get; set; }
}

internal sealed class ChangeEmail
{
    /// <summary>
    /// Enable change email functionality
    /// 
    /// @default false
    /// </summary>
    public bool? Enabled { get; set; } = false;

    /// <summary>
    /// Require email verification before changing the email
    /// 
    /// @default true
    /// </summary>
    private bool? RequireEmailVerification { get; set; } = true;
}

internal sealed class DeleteUser
{
    /// <summary>
    /// Enable user deletion functionality
    /// 
    /// @default true
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Require email verification before deleting the user
    /// 
    /// @default false
    /// </summary>
    public bool? RequireEmailVerification { get; set; } = false;

    /// <summary>
    /// The expiration time for the delete token.
    /// 
    /// @default 1 day (60 * 60 * 24) in seconds
    /// </summary>
    public int? DeleteTokenExpiresIn { get; set; } = 60 * 60 * 24;
}