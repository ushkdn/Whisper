using Microsoft.EntityFrameworkCore;
using Whisper.Auth.Domain.Entities;
using Whisper.Auth.Features.AuthTokens;
using Whisper.Shared.Domain.Entities.Base;

namespace Whisper.Auth.Infrastructure.Persistence.Repositories;

public sealed class RefreshTokenRepository(WhisperAuthDbContext context) : IRefreshTokenRepository
{
    public async Task<Lazy<RefreshTokenEntity>> CreateAsync(RefreshTokenEntity refreshToken, CancellationToken cancellationToken = default)
    {
        if (refreshToken is EntityBase baseEntity)
        {
            baseEntity.DateCreated = DateTime.UtcNow;
            baseEntity.DateUpdated = DateTime.UtcNow;
        }

        var storedRefreshToken = await context.RefreshTokens
            .AddAsync(refreshToken, cancellationToken);

        return new Lazy<RefreshTokenEntity>(() => storedRefreshToken.Entity);
    }

    public async Task<RefreshTokenEntity> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken)
            ?? throw new KeyNotFoundException($"Unable to find refresh-token for user with id:{userId}");
    }

    public async Task<RefreshTokenEntity> GetByIdAsync(Guid refreshTokenId, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == refreshTokenId, cancellationToken)
            ?? throw new KeyNotFoundException($"Unable to find refresh-token with id:{refreshTokenId}");
    }
}