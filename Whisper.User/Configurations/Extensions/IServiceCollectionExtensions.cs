using System.Reflection;
using Microsoft.OpenApi.Models;
using Whisper.Shared.Configurations.Extensions;

namespace Whisper.User.Configurations.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        services.AddSwagger().AddMediator();
        
        return services;
    }
    
    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Whisper User API",
                Version = "v1",
                Description = "Whisper User API which provides base user operations",
                Contact = new OpenApiContact
                {
                    Name = "",
                    Email = "",
                    Url = new Uri("https://github.com/ushkdn/Whisper")
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);
        });
        return services;
    }
    
    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        return services;
    }
    
}