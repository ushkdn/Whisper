using MediatR;
using Whisper.Shared.Features.Base;

namespace Whisper.User.Features.User.LogIn;

public record UserLogInRequest
(
    string Email,
    string Password
) : IRequest<HandlerResponse<UserLogInResponse>>;