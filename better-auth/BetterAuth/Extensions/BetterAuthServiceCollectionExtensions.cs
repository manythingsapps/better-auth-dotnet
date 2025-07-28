using BetterAuth.Configurations;
using BetterAuth.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BetterAuth.Extensions;

public static class BetterAuthServiceCollectionExtensions
{
    /// <summary>
    /// Initializes the BetterAuth service options with values from the configuration.
    /// 
    /// Added the default secondary storage implementation which stores in memory.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configurationKey"></param>
    /// <returns></returns>
    public static IServiceCollection AddBetterAuth(this IServiceCollection services, string configurationKey = "BetterAuth")
    {
        services
            .AddOptions<BetterAuthOptions>()
            .BindConfiguration(configurationKey)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddSingleton<ISecondaryStorage, DefaultSecondaryStorage>();

        return services;
    }

    /// <summary>
    /// Adds the BetterAuth database context to the service collection.
    /// 
    /// Use this method to configure the database context for your choice of database provider (e.g., SQL Server, PostgreSQL, SQLite).
    /// </summary>
    /// <param name="services"></param>
    /// <param name="optionsBuilderAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddBetterAuthDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilderAction)
    {
        services
            .AddDbContext<BetterAuthDbContext>(options =>
            {
                optionsBuilderAction(options);
            });

        return services;
    }
}
