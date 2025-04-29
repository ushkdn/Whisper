namespace Whisper.User.Features.User.Register;

public record RegisterUserCommand
(
        string Surname,
        
        string Name,
        
        string Username,
        
        string Email,
        
        string Password,
        
        string ConfirmPassword,
        
        DateTime BirthDay
);