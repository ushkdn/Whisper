using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Whisper.Auth.Configurations.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        services.AddSwagger();
        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Whisper Auth API",
                Version = "v1",
                Description = "Whisper Auth API which provides base auth operations",
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
}