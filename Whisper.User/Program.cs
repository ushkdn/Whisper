using Whisper.User.Configurations.Extensions;
using Whisper.User.Features.Extensions;
using Whisper.User.Infrastructure.Extensions;

namespace Whisper.User;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Host.AddEnvSupport();
        builder.Services.AddConfigurations();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddFeatures();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", string.Empty);
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}