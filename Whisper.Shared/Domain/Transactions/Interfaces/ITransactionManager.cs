namespace Whisper.Shared.Domain.Transactions.Interfaces;

public interface ITransactionManager
{
    int SaveChanges();

    Task<int> SaveChangesAsync();
}