using BetterAuth.Db.Entities;

namespace BetterAuth.Configurations;

internal sealed class SessionOptions
{
    /// <summary>
    /// The model name for the session.
    /// 
    /// @default "session"
    /// </summary>
    public string? ModelName { get; set; } = "session";

    /// <summary>
    /// Expiration time for the session token. The value
    /// should be in seconds.
    /// @default 7 days (60 * 60 * 24 * 7)
    /// </summary>
    public int? ExpiresIn { get; set; } = 60 * 60 * 24 * 7;

    /// <summary>
    /// How often the session should be refreshed. The value
    /// should be in seconds.
    /// If set 0 the session will be refreshed every time it is used.
    /// @default 1 day (60 * 60 * 24)
    /// </summary>
    public int? UpdateAge { get; set; } = 60 * 60 * 24;

    /// <summary>
    /// Disable session refresh so that the session is not updated
    /// regardless of the `updateAge` option.
    /// 
    /// @default false
    /// </summary>
    public bool? DisableSessionRefresh { get; set; } = false;

    /// <summary>
    /// By default if secondary storage is provided
    /// the session is stored in the secondary storage.
    /// 
    /// Set this to true to store the session in the database
    /// as well.
    /// 
    /// Reads are always done from the secondary storage.
    /// 
    /// @default false
    /// </summary>
    public bool? StoreSessionInDatabase { get; set; } = false;

    /// <summary>
    /// By default, sessions are deleted from the database when secondary storage
    /// is provided when session is revoked.
    /// 
    /// Set this to true to preserve session records in the database,
    /// even if they are deleted from the secondary storage.
    /// 
    /// @default false
    /// </summary>
    public bool? PreserveSessionInDatabase { get; set; } = false;

    /// <summary>
    /// Enable caching session in cookie
    /// </summary>
    public CookieCache? CookieCache { get; set; }

    /// <summary>
    /// The age of the session to consider it fresh.
	///
	/// This is used to check if the session is fresh
    ///    for sensitive operations. (e.g.deleting an account)
	///
	/// If the session is not fresh, the user should be prompted
	/// to sign in again.
    ///
    ///   
    /// If set to 0, the session will be considered fresh every time. (⚠︎ not recommended)
	///
	/// @default 1 day(60 * 60 * 24)
    /// </summary>
    public int? FreshAge { get; set; } = 60 * 60 * 24;
}

internal sealed class CookieCache
{
    /// <summary>
    /// max age of the cookie
    /// @default 5 minutes (5 * 60)
    /// </summary>
    public int? MaxAge { get; set; } = 5 * 60;

    /// <summary>
    /// Enable caching session in cookie
    /// @default false
    /// </summary>
    public bool? Enabled { get; set; } = false;
}
