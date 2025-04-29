using Whisper.User.Domain.Entities;

namespace Whisper.User.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Lazy<UserEntity>> CreateAsync(UserEntity user, CancellationToken cancellationToken);
    
    Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}