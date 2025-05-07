using Whisper.Shared.Configurations.Extensions;

namespace Whisper.User.Configurations.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddEnvSupport(this IHostBuilder hostBuilder, string envFileName)
    {
        hostBuilder.ConfigureAppConfiguration
        (
            (hostingContext, config) =>
            {
                config.AddDotEnvConfiguration(envFileName);
            }
        );

        return hostBuilder;
    }
}