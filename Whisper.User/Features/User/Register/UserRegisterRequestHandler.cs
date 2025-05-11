using DevOne.Security.Cryptography.BCrypt;
using FluentValidation;
using MapsterMapper;
using MassTransit;
using MediatR;
using Whisper.Shared.Application.Abstractions.Persistence;
using Whisper.Shared.Features.Base;
using Whisper.Shared.Messaging.Events;
using Whisper.User.Domain.Entities;

namespace Whisper.User.Features.User.Register;

public class UserRegisterRequestHandler(
    IUserRepository userRepository,
    IValidator<UserRegisterRequest> validator,
    IMapper mapper,
    ITransactionManager transactionManager,
    IPublishEndpoint publishEndpoint) : IRequestHandler<UserRegisterRequest, HandlerResponse<UserRegisterResponse>>
{
    public async Task<HandlerResponse<UserRegisterResponse>> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            return new HandlerResponse<UserRegisterResponse>
            {
                Success = false,
                Data = null,
                Message = errorMessages
            };
        }

        cancellationToken.ThrowIfCancellationRequested();
        var isUserExists = await userRepository.GetUserByEmailAsync(request.Email!, cancellationToken);

        if (isUserExists is not null)
        {
            return new HandlerResponse<UserRegisterResponse>
            {
                Success = false,
                Data = null,
                Message = "User already exists"
            };
        }

        request.Password = BCryptHelper.HashPassword(request.Password, BCryptHelper.GenerateSalt());

        var storedUser = await userRepository.CreateAsync(mapper.Map<UserEntity>(request), cancellationToken);

        await transactionManager.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish(new UserRegisteredEvent(storedUser.Value.Id), cancellationToken);

        return new HandlerResponse<UserRegisterResponse>
        {
            Success = true,
            Data = mapper.Map<UserRegisterResponse>(storedUser.Value),
            Message = "User registered"
        };
    }
}