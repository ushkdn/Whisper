using Microsoft.EntityFrameworkCore;
using Whisper.Auth.Features.AuthTokens;
using Whisper.Auth.Infrastructure.Persistence.Repositories;
using Whisper.Shared.Application.Abstractions.Persistence;
using Whisper.Shared.Infrastructure.Persistence.Transactions;

namespace Whisper.Auth.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration,
        string dbConnectionStringKey)
    {
        var dbConnectionString = configuration
                                     .GetSection("Databases")
                                     .GetSection("ConnectionStrings")
                                     .GetSection(dbConnectionStringKey)
                                     .Value
                                 ?? throw new InvalidOperationException($"{dbConnectionStringKey} configuration not found");

        services.AddDbContext<WhisperAuthDbContext>(options =>
            options
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseNpgsql
                (
                    dbConnectionString,
                    x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                )
        );

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ITransactionManager, TransactionManager<WhisperAuthDbContext>>();

        return services;
    }
}