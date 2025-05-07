using Microsoft.EntityFrameworkCore;
using Whisper.User.Domain.Entities;
using Whisper.User.Features.User;

namespace Whisper.User.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(WhisperUserDbContext context) : IUserRepository
{
    public async Task<UserEntity> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Users
            .Where(x => x.Id == userId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException($"Unable to find user with specified id:{userId}");
    }

    public async Task<Lazy<UserEntity>> CreateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        var storedUser = await context.Users.AddAsync(user, cancellationToken);
        
        return new Lazy<UserEntity>(() => storedUser.Entity);
    }

    public async Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .Where(x => x.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
    }
}