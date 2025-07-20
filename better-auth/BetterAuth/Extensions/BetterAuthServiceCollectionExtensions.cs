using BetterAuth.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BetterAuth.Extensions;

public static class BetterAuthServiceCollectionExtensions
{
    public static IServiceCollection AddBetterAuth(this IServiceCollection services, string configurationKey = "BetterAuth")
    {
        services
            .AddOptions<BetterAuthOptions>()
            .BindConfiguration(configurationKey)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}
