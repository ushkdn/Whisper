using Whisper.Shared.Configurations.Extensions;

namespace Whisper.User.Configurations.Extensions;

public static class IHostBuilderExtensions
{
    public static IHostBuilder AddEnvSupport(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureAppConfiguration
        (
            (hostingContext, config) =>
            {
                config.AddDotEnvConfiguration("whisper.user.env");
            }
        );
        
        return hostBuilder;
    }
}