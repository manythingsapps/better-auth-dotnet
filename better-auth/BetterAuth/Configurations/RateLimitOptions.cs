namespace BetterAuth.Configurations;
public sealed class RateLimitOptions
{
    /// <summary>
    /// By default, rate limiting is only
    /// enabled on production.
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Default window to use for rate limiting. The value
    /// should be in seconds.
    /// 
    /// @default 10 seconds
    /// </summary>
    public int? Window { get; set; } = 10;

    /// <summary>
    /// The default maximum number of requests allowed within the window.
    /// 
    /// @default 100 requests
    /// </summary>
    public int? Max { get; set; } = 100;

    /// <summary>
    /// Custom rate limit rules to apply to
    /// specific paths.
    /// </summary>
    public Dictionary<string, CustomRulesOptions>? CustomRules { get; set; }

    /// <summary>
    /// Storage configuration
    /// 
    /// By default, rate limiting is stored in memory. If you passed a
    /// secondary storage, rate limiting will be stored in the secondary
    /// storage.
    /// 
    /// @default "memory"
    /// </summary>
    public RateLimitStorageType? Storage { get; set; } = RateLimitStorageType.memory;
}


public sealed class  CustomRulesOptions
{
    /// <summary>
    /// The window to use for the custom rule.
    /// </summary>
    public int? Window { get; set; }

    /// <summary>
    /// The maximum number of requests allowed within the window.
    /// </summary>
    public int? Max { get; set; }
}

public enum RateLimitStorageType
{
    /// <summary>
    /// In memory storage.
    /// </summary>
    memory,
    /// <summary>
    /// Primary database.
    /// </summary>
    database,
    /// <summary>
    /// Secondary storage.
    /// </summary>
    secondarystorage
}