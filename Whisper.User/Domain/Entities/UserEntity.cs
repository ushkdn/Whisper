using Whisper.Shared.Domain.Entities.Base;

namespace Whisper.User.Domain.Entities;

public class UserEntity : EntityBase
{
    public required string Surname { get; set; }
    
    public required string Name { get; set; }
    
    public required string Username { get; set; }
    
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    public required DateOnly BirthDay { get; set; }
    
    public required bool IsVerified { get; set; } = false;
}