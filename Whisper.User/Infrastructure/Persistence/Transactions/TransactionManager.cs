using Whisper.Shared.Domain.Transactions.Interfaces;

namespace Whisper.User.Infrastructure.Persistence.Transactions;

public sealed class TransactionManager(WhisperUserDbContext context) : ITransactionManager, IDisposable, IAsyncDisposable
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