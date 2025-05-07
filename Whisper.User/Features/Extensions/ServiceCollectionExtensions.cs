using FluentValidation;
using Mapster;
using Whisper.User.Features.User.Register;

namespace Whisper.User.Features.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddMapping().AddValidation();
        
        return services;
    }
    
    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();
        
        UserRegisterMappingConfig.Configure();
        
        return services;
    }
    
    

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IFeaturesAssembly>();
        return services;
    }
    
}