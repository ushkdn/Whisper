using DevOne.Security.Cryptography.BCrypt;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Whisper.Shared.Domain.Transactions.Interfaces;
using Whisper.Shared.Features.Base;
using Whisper.User.Domain.Entities;

namespace Whisper.User.Features.User.Register;

public class UserRegisterRequestHandler(
    IUserRepository userRepository, 
    IValidator<UserRegisterRequest> validator,
    IMapper mapper,
    ITransactionManager transactionManager) : IRequestHandler<UserRegisterRequest, HandlerResponse<UserRegisterResponse>>
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
        var storedUser = await userRepository.GetUserByEmailAsync(request.Email!, cancellationToken );
        
        if (storedUser is not null)
        {
            return new HandlerResponse<UserRegisterResponse>
            {

                Success = false,
                Data = null,
                Message = "User already exists"
            };
        }

        request.Password = BCryptHelper.HashPassword(request.Password, BCryptHelper.GenerateSalt());
        
        var result = mapper.Map<UserRegisterResponse>(userRepository.CreateAsync(
            mapper.Map<UserEntity>(request), cancellationToken).Result);

        await transactionManager.SaveChangesAsync();
        
        //broker event sending here to authservice for token creation.

        return new HandlerResponse<UserRegisterResponse>
        {
            Success = true,
            Data = result,
            Message = "User registered"
        };
    }
}