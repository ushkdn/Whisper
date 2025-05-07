using Whisper.Auth.Configurations.Extensions;
using Whisper.Auth.Infrastructure.Extensions;

namespace Whisper.Auth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.AddEnvSupport("whisper.auth.env");

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddInfrastructure(builder.Configuration, "PostgreSQL-AuthDb");
        builder.Services.AddConfigurations();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}