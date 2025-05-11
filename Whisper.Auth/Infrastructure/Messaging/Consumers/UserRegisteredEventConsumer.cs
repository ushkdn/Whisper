using MassTransit;
using MediatR;
using Whisper.Auth.Features.AuthTokens.Create;
using Whisper.Shared.Messaging.Events;

namespace Whisper.Auth.Infrastructure.Messaging.Consumers;

public class UserRegisteredEventConsumer(IMediator mediator) : IConsumer<UserRegisteredEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var transferedMessage = context.Message;

        var authTokensCreateRequest = new AuthTokensCreateRequest(transferedMessage.UserId);

        await mediator.Send(authTokensCreateRequest);
    }
}