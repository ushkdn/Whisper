using FluentValidation;
using MediatR;
using Whisper.Auth.Domain.Entities;
using Whisper.Shared.Application.Abstractions.Persistence;
using Whisper.Shared.Features.Base;

namespace Whisper.Auth.Features.AuthTokens.Create;

public class AuthTokensCreateRequestHandler(
    IRefreshTokenRepository refreshTokenRepository,
    IValidator<AuthTokensCreateRequest> validator,
    ITransactionManager transactionManager) : IRequestHandler<AuthTokensCreateRequest, HandlerResponse<AuthTokensCreateResponse>>
{
    public async Task<HandlerResponse<AuthTokensCreateResponse>> Handle(AuthTokensCreateRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            return new HandlerResponse<AuthTokensCreateResponse>
            {
                Success = false,
                Data = null,
                Message = errorMessages
            };
        }

        cancellationToken.ThrowIfCancellationRequested();

        var refreshTokenEntity = new RefreshTokenEntity
        {
            UserId = request.UserId,
            Token = "penes",
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow,
            ExpireDate = DateTime.UtcNow.AddDays(7)
        };

        await refreshTokenRepository.CreateAsync(refreshTokenEntity, cancellationToken);

        await transactionManager.SaveChangesAsync(cancellationToken);

        return new HandlerResponse<AuthTokensCreateResponse>
        {
            Success = true,
            Data = null,
            Message = "good"
        };
    }
}