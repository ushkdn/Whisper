namespace Whisper.User.Features.User.Register;

public record UserRegisterResponse(
    Guid Id,
    string Surname,
    string Name,
    string Username,
    string Email,
    string BirthDay,
    DateTime DateCreated);