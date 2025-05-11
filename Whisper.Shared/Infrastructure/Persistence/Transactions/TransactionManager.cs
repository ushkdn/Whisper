using Microsoft.EntityFrameworkCore;
using Whisper.Shared.Application.Abstractions.Persistence;

namespace Whisper.Shared.Infrastructure.Persistence.Transactions;

public sealed class TransactionManager<T>(T context) : ITransactionManager, IDisposable, IAsyncDisposable where T : DbContext
{
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}