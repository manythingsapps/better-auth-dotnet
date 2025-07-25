using Microsoft.Extensions.Caching.Hybrid;

namespace BetterAuth.Db.Repositories;

/// <summary>
/// This is used to store session and rate limit data.
/// </summary>
internal class SecondaryStorage : ISecondaryStorage
{
    private readonly HybridCache _cache;

    public SecondaryStorage(HybridCache cache)
    {
        _cache = cache;
    }

    public virtual async Task<string?> Get(string key, CancellationToken ct)
    {
        return await _cache.GetOrCreateAsync<string>(key, async (cancellationToken) =>
        {
            return await Task.FromResult(string.Empty);
        }, cancellationToken: ct);
    }

    public virtual async Task<string?> Set(string key, string value, int? ttl, CancellationToken ct)
    {
        await _cache.SetAsync<string>(key, value, 
            new HybridCacheEntryOptions { 
                Expiration = ttl.HasValue ? TimeSpan.FromSeconds(ttl.Value) : TimeSpan.FromSeconds(60 * 60 * 24)
            }, cancellationToken: ct);

        return await Task.FromResult(value);
    }

    public virtual async Task<string?> Delete(string key, CancellationToken ct)
    {
        var value = await Get(key, ct);

        await _cache.RemoveAsync(key, ct);

        return value;
    }
}
