using Whisper.Auth.Infrastructure.Persistence.Extensions;

namespace Whisper.Auth.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure
    (
        this IServiceCollection services,
        IConfiguration configuration,
        string dbConnectionStringKey
    )
    {
        services.AddPersistence(configuration, dbConnectionStringKey);
        return services;
    }
}