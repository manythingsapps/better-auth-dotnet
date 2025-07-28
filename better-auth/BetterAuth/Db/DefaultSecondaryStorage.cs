using Microsoft.Extensions.Caching.Hybrid;

namespace BetterAuth.Db;

/// <summary>
/// Default implementation of secondary storage for Better Auth.
/// 
/// This uses Hybrid cache to implement an in-memory cache to store key-value pairs.
/// 
/// All the methods are virtual to allow overriding in derived classes.
/// </summary>
public class DefaultSecondaryStorage : ISecondaryStorage
{
    private readonly HybridCache _cache;

    public DefaultSecondaryStorage(
        HybridCache cache)
    {
        _cache = cache;
    }

    public virtual async Task<string?> Get(string key, CancellationToken ct)
    {
        var value = await _cache.GetOrCreateAsync<string>(key, token =>
        {
            return ValueTask.FromResult(string.Empty);
        },
        options: null,
        tags: null,
        ct);

        return string.IsNullOrEmpty(value) ? null : value;
    }

    public virtual async Task<string?> Set(string key, string value, int? ttl, CancellationToken ct)
    {
        await _cache.SetAsync(
            key,
            value,
            options: new HybridCacheEntryOptions { Expiration = TimeSpan.FromSeconds(ttl!.Value) },
            tags: null,
            ct);

        return value;
    }

    public virtual async Task<string?> Delete(string key, CancellationToken ct)
    {
        var value = await Get(key, ct);

        await _cache.RemoveAsync(key, ct);

        return value;
    }
}
