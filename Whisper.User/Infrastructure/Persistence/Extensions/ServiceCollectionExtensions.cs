﻿using Microsoft.EntityFrameworkCore;
using Whisper.Shared.Application.Abstractions.Persistence;
using Whisper.Shared.Infrastructure.Persistence.Transactions;
using Whisper.User.Features.User;
using Whisper.User.Infrastructure.Persistence.Repositories;

namespace Whisper.User.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence
    (
        this IServiceCollection services,
        IConfiguration configuration,
        string dbConnectionStringKey
    )
    {
        var dbConnectionString = configuration
                                     .GetSection("Databases")
                                     .GetSection("ConnectionStrings")
                                     .GetSection(dbConnectionStringKey)
                                     .Value
                                 ?? throw new InvalidOperationException($"{dbConnectionStringKey} configuration not found");

        services.AddDbContext<WhisperUserDbContext>(options =>
            options
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseNpgsql
                (
                    dbConnectionString,
                    x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                )
        );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITransactionManager, TransactionManager<WhisperUserDbContext>>();

        return services;
    }
}