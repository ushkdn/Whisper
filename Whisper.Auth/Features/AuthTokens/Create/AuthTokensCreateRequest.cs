using MediatR;
using Whisper.Shared.Features.Base;

namespace Whisper.Auth.Features.AuthTokens.Create;

public record AuthTokensCreateRequest(Guid UserId) : IRequest<HandlerResponse<AuthTokensCreateResponse>>;