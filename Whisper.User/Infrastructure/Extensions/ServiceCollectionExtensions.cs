using Whisper.Shared.Configurations.Extensions;
using Whisper.User.Infrastructure.Persistence.Extensions;

namespace Whisper.User.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddPersistence(configuration, "PostgreSQL-UserDb");

        return services;
    }
}