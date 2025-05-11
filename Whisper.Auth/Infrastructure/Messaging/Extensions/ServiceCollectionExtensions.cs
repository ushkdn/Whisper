using MassTransit;
using Whisper.Auth.Infrastructure.Messaging.Consts;
using Whisper.Auth.Infrastructure.Messaging.Consumers;
using Whisper.Shared.Infrastructure.Messaging;

namespace Whisper.Auth.Infrastructure.Messaging.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserRegisteredEventConsumer>();

            x.UsingRabbitMq((context, config) =>
            {
                var rabbitmqConfs = configuration.GetSection("Messaging").GetSection("MassTransit-RabbitMQ").Get<RabbitMQSettings>();

                config.Host("localhost", h =>
                {
                    h.Username(rabbitmqConfs.Username);
                    h.Password(rabbitmqConfs.Password);
                });

                config.ReceiveEndpoint(Queues.USER_REGISTERED, c =>
                {
                    c.ConfigureConsumer<UserRegisteredEventConsumer>(context);
                });

                config.ClearSerialization();
                config.UseRawJsonSerializer();
                config.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}