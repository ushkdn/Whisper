using Microsoft.EntityFrameworkCore;
using Whisper.Shared.Domain.Transactions.Interfaces;

namespace Whisper.Shared.Infrastructure.Persistence.Transactions;

public sealed class TransactionManager<T>(T context) : ITransactionManager, IDisposable, IAsyncDisposable where T : DbContext
{
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
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