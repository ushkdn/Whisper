using Whisper.User.Domain.Entities;

namespace Whisper.User.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserByIdAsync(Guid userId);
}