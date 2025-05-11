namespace Whisper.Shared.Application.Abstractions.Persistence;

public interface ITransactionManager
{
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}