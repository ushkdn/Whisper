using FluentValidation;
using Mapster;
using Whisper.User.Features;
using Whisper.User.Features.User.Register;
using Whisper.User.Infrastructure.Messaging.Extensions;
using Whisper.User.Infrastructure.Persistence.Extensions;

namespace Whisper.User.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string dbConnectionStringKey)
    {
        services
            .AddPersistence(configuration, dbConnectionStringKey)
            .AddMapping()
            .AddValidation()
            .AddMediator()
            .AddMessaging(configuration);

        return services;
    }

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();

        UserRegisterMappingConfig.Configure();

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