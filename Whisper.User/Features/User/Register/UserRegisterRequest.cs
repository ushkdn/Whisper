using System.Runtime.InteropServices.JavaScript;
using MediatR;
using Whisper.User.Features.Base;

namespace Whisper.User.Features.User.Register;

public class UserRegisterRequest : IRequest<HandlerResponse<UserRegisterResponse>>
{
    public string? Surname { get; init; }
    public string? Name { get; init; }
    public string? Username { get; init; }
    public string? Email { get; init; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; init; }
    public DateOnly? BirthDay { get; init; }
}
