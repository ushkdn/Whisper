using Microsoft.EntityFrameworkCore;
using Whisper.User.Domain.Entities;
using Whisper.User.Domain.Interfaces.Repositories;

namespace Whisper.User.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(WhisperUserDbContext context) : IUserRepository
{
    public async Task<UserEntity> GetUserByIdAsync(Guid userId)
    {
        return await context.Users
                                    .Where(x => x.Id == userId)
                                    .FirstOrDefaultAsync() 
               ?? throw new KeyNotFoundException($"User with specified id: {userId} not found");
    }
}