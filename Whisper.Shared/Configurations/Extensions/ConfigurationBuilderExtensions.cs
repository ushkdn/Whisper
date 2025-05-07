using DotNetEnv;
using Microsoft.Extensions.Configuration;

namespace Whisper.Shared.Configurations.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddDotEnvConfiguration
    (
        this IConfigurationBuilder configurationBuilder, 
        string envFileName
    )            
    {
        var projectPath = Directory.GetCurrentDirectory();
        var envFilePath = Path.Combine(projectPath, envFileName);

        if (File.Exists(envFilePath))
        {
            Env.Load(envFilePath);
        }
        else
        {
            throw new FileNotFoundException("Unable to find configuration file with environment variables (.env) via specified path");
        }

        configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder;
    }
}