namespace BetterAuth.Db;

/// <summary>
/// Interface for secondary storage operations.
/// 
/// Use this to define a secondary storage mechanism for Better Auth.
/// </summary>
public interface ISecondaryStorage
{
    Task<string?> Get(string key, CancellationToken ct);

    Task<string?> Set(string key, string value, int? ttl, CancellationToken ct);

    Task<string?> Delete(string key, CancellationToken ct);
}
