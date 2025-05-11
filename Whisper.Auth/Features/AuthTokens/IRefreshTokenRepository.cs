using Whisper.Auth.Domain.Entities;

namespace Whisper.Auth.Features.AuthTokens;

public interface IRefreshTokenRepository
{
    Task<Lazy<RefreshTokenEntity>> CreateAsync(RefreshTokenEntity entity, CancellationToken cancellationToken = default);

    Task<RefreshTokenEntity> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<RefreshTokenEntity> GetByIdAsync(Guid refreshTokenId, CancellationToken cancellationToken = default);
}