using BetterAuth.Api.Responses;
using BetterAuth.Configurations;
using BetterAuth.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Xml.Linq;

namespace BetterAuth.Services;

internal sealed class AuthService
{
    private readonly BetterAuthOptions _betterAuthOptions;

    public AuthService(IOptions<BetterAuthOptions> betterAuthOptions)
    {
        _betterAuthOptions = betterAuthOptions.Value;
    }

    private Func<string, CookieOptions, CookieCreationResponse> CreateCookieGetter()
    {
        var isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production" ||
                           Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging";

        var secure =
        _betterAuthOptions.Advanced?.UseSecureCookies != null
            ? _betterAuthOptions.Advanced?.UseSecureCookies
            : _betterAuthOptions.BaseURL != null
                ? _betterAuthOptions.BaseURL.StartsWith("https://")
                    ? true
                    : false
                : isProduction;

        var secureCookiePrefix = secure!.Value ? "__Secure-" : "";

        var crossSubdomainEnabled = _betterAuthOptions.Advanced?.CrossSubDomainCookies?.Enabled;

        var domain = crossSubdomainEnabled == true
            ? _betterAuthOptions.Advanced?.CrossSubDomainCookies?.Domain ??
                (!string.IsNullOrEmpty(_betterAuthOptions.BaseURL) ? new Uri(_betterAuthOptions.BaseURL).Host : null)
            : null;

        if (crossSubdomainEnabled == true && string.IsNullOrEmpty(domain))
        {
            throw new BetterAuthError(
                "MISSING_CONFIGURATION",
                "baseURL is required when crossSubdomainCookies are enabled"    
            );
        }

        return (string cookieName, CookieOptions overrideAttributes) =>
        {
            var prefix = _betterAuthOptions.Advanced?.CookiePrefix ?? "better-auth";
            var name =
                _betterAuthOptions.Advanced?.Cookies?.[cookieName as "session_token"]?.name ||
			    `${ prefix}.${ cookieName}`;
        };
    }
}
