using FluentValidation;
using Mapster;
using Whisper.Auth.Features;
using Whisper.Auth.Infrastructure.Messaging.Extensions;
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
        services
            .AddPersistence(configuration, dbConnectionStringKey)
            .AddMessaging(configuration)
            .AddValidation()
            .AddMapping()
            .AddMediator();
        return services;
    }

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();

        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IFeaturesAssembly>();
        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        return services;
    }
}