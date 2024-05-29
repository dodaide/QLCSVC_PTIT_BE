using System.Data.Common;

namespace Domain.Interfaces.InfrastructureInterfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    DbConnection Connection { get; }
    DbTransaction? Transaction { get; }
    Task CommitAsync();
    Task BeginTransactionAsync();
    Task RollbackAsync();
}