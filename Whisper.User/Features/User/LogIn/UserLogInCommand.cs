namespace Whisper.User.Features.User.LogIn;

public record UserLogInCommand
(
    string Email,
    string Password
);