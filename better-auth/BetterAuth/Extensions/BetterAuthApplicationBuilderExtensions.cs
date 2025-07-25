using Microsoft.AspNetCore.Builder;

namespace BetterAuth.Extensions;

public static class BetterAuthApplicationBuilderExtensions
{
    public static IApplicationBuilder UseBetterAuth(this IApplicationBuilder app)
    {
        return app;
    }
}
