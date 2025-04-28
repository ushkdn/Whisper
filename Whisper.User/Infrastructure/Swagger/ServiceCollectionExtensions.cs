using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Whisper.User.Infrastructure.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
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
}