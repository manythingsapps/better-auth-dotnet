using BetterAuth.Configurations;
using BetterAuth.Db;
using BetterAuth.Db.Repositories;
using Microsoft.EntityFrameworkCore;
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

        services.AddHybridCache();

        services.AddSingleton<IRepository, Repository>();
        services.AddSingleton<ISecondaryStorage, SecondaryStorage>();
        services.AddScoped<IAuthContext, AuthContext>();

        return services;
    }

    public static IServiceCollection AddBetterAuthDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb)
    {
        services
            .AddDbContext<BetterAuthDbContext>((serviceProvider, options) =>
            {
                configureDb(options);
            });

        return services;
    }
}
