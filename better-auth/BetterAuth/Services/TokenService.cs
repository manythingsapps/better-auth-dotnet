using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BetterAuth.Services;

internal sealed class TokenService
{
    internal static string SignJWT(object payload, string secret, int? expiresIn = 3600)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Claims = ConvertPayloadToClaims(payload),
            Expires = DateTime.UtcNow.AddSeconds(expiresIn!.Value),
            SigningCredentials = credentials,
            IssuedAt = DateTime.UtcNow
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static Dictionary<string, object> ConvertPayloadToClaims(object payload)
    {
        var claims = new Dictionary<string, object>();

        if (payload == null)
            return claims;

        var properties = payload.GetType().GetProperties();
        foreach (var prop in properties)
        {
            claims.Add(prop.Name, prop.GetValue(payload)!);
        }

        return claims;
    }
}
