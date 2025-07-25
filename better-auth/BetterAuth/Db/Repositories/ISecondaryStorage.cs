namespace BetterAuth.Db.Repositories;

/// <summary>
/// This is used to store session and rate limit data.
/// </summary>
internal interface ISecondaryStorage
{
    Task<string?> Get(string key, CancellationToken ct);
    Task<string?> Set(string key, string value, int? ttl, CancellationToken ct);
    Task<string?> Delete(string key, CancellationToken ct);
}
