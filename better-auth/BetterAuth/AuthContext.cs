using BetterAuth.Configurations;
using BetterAuth.Db.Entities;
using BetterAuth.Db.Repositories;
using BetterAuth.DTOs;
using BetterAuth.Helpers;
using BetterAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BetterAuth;

public class AuthContext : IAuthContext
{
    private readonly HttpContext _context;
    private readonly BetterAuthOptions _betterAuthOptions;
    private readonly IRepository _repository;
    private readonly ISecondaryStorage _secondaryStorage;

    internal AuthContext(
        IHttpContextAccessor httpContextAccessor,
        IOptions<BetterAuthOptions> betterAuthOptions,
        IRepository repository,
        ISecondaryStorage secondaryRepository
        )
    {
        _context = httpContextAccessor.HttpContext;
        _betterAuthOptions = betterAuthOptions.Value;
        _repository = repository;
        _secondaryStorage = secondaryRepository;
    }

    public virtual Task SendVerificationEmail(User user, string url, string token) => Task.CompletedTask;

    public virtual async Task<Session> CreateSession(string userId, bool dontRememberMe, CancellationToken ct = default!)
    {
        var headers = _context.Request.Headers;

        var sessionTimeoutInSec = _betterAuthOptions.Session?.ExpiresIn ?? (60 * 60 * 24);
        var expiresAt = dontRememberMe ? DateTime.UtcNow.AddSeconds(60 * 60 * 24) : DateTime.UtcNow.AddSeconds(sessionTimeoutInSec);
        var data = new Session
        {
            IpAddress = headers is not null ? IpAddressService.GetIp(_context, _betterAuthOptions) : null,
            UserAgent = headers is not null ? headers["User-Agent"].ToString() : null,
            ExpiresAt = expiresAt,
            UserId = userId,
            Token = StringHelpers.GenerateId(32),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.CreateSession(data, ct);

        var currentList = await _secondaryStorage.Get($"active-sessions-{userId}", ct);
        var time = DateTime.Now;
        var sessionList = currentList != null ? JsonConvert.DeserializeObject<SessionToken[]>(currentList) : [];
        var newSession = new SessionToken
        {
            Token = data.Token,
            ExpiresAt = data.ExpiresAt.Ticks
        };

        sessionList = sessionList is not null ? sessionList.Where(s => s.ExpiresAt > time.Ticks)            
            .Append(newSession)
            .ToArray()
            : [newSession];

        await _secondaryStorage.Set($"active-sessions-{userId}", JsonConvert.SerializeObject(sessionList), sessionTimeoutInSec, ct);

        return data;
    }

    public virtual async Task<BetterAuthCookie> GetCookie(string name)
    {
        _context.Session
    }
}
