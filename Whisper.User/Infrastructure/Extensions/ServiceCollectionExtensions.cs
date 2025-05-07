using Whisper.Shared.Configurations.Extensions;
using Whisper.User.Infrastructure.Persistence.Extensions;

namespace Whisper.User.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration,
        string dbConnectionStringKey)
    {
        services.AddPersistence(configuration, dbConnectionStringKey);

        return services;
    }
}