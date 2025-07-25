using BetterAuth.Configurations;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BetterAuth.Services;

internal static class IpAddressService
{
    public static string? GetIp(
        HttpContext httpContext,
        BetterAuthOptions betterAuthOptions)
    {
        if(betterAuthOptions.Advanced?.IpAddress?.DisableIpTracking == true)
        {
            return null;
        }

        var headers = httpContext.Request.Headers;

        var defaultHeaders = new[] { "x-forwarded-for" };

        var ipHeaders = betterAuthOptions.Advanced?.IpAddress?.IpAddressHeaders ?? defaultHeaders;

        foreach (var key in ipHeaders) {
            headers.TryGetValue(key, out var value);
            if (!string.IsNullOrEmpty(value))
            {
                var ip = value.ToString().Split(",")[0].Trim();
                if (IsValidIP(ip))
                {
                    return ip;
                }
            }
        }

        return null;
    }

    private static bool IsValidIP(string ip)
    {
        if (IPAddress.TryParse(ip, out IPAddress? address))
        {
            if (address?.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                // Additional IPv4 validation (since TryParse accepts some non-standard IPv4 formats)
                var parts = ip.Split('.');
                return parts.Length == 4 && parts.All(p => byte.TryParse(p, out _));
            }
            return true; // Valid IPv6
        }
        return false;
    }
}
