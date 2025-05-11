using MassTransit;
using Whisper.Shared.Infrastructure.Messaging;

namespace Whisper.User.Infrastructure.Messaging.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, config) =>
            {
                var rabbitmqConfs = configuration.GetSection("Messaging").GetSection("MassTransit-RabbitMQ").Get<RabbitMQSettings>();

                config.Host("localhost", h =>
                {
                    h.Username(rabbitmqConfs.Username);
                    h.Password(rabbitmqConfs.Password);
                });

                config.ClearSerialization();
                config.UseRawJsonSerializer();
            });
        });
        return services;
    }
}