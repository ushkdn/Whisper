using Mapster;
using Whisper.User.Domain.Entities;

namespace Whisper.User.Features.User.Register;

public static class UserRegisterMappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<UserRegisterRequest, UserEntity>.NewConfig();
    }
}