using FluentValidation;

namespace Whisper.Auth.Features.AuthTokens.Create;

public class AuthTokensCreateRequestValidator : AbstractValidator<AuthTokensCreateRequest>
{
    public AuthTokensCreateRequestValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty()
            .WithErrorCode("400")
            .WithMessage("UserId cannot be empty")
            .Must(userId => userId != Guid.Empty)
            .WithMessage("UserId must be a valid non-empty GUID")
            .WithErrorCode("400");
    }
}