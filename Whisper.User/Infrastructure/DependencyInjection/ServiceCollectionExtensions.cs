using Whisper.Shared.Configurations.Extensions;
using Whisper.User.Infrastructure.Persistence.Extensions;
using Whisper.User.Infrastructure.Swagger;

namespace Whisper.User.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices
    (
        this IServiceCollection services, 
        IHostBuilder hostBuilder, 
        IConfiguration configuration
    )
    {
        hostBuilder.ConfigureAppConfiguration
        (
            (hostingContext, config) =>
            {
                config.AddDotEnvConfiguration("whisper.user.env");
            }
        );
        
        services.AddSwagger();
        
        services.AddPersistence(configuration, "PostgreSQL-UserDb");

        return services;
    }
}