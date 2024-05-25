using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.DLInterfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }
        DbTransaction? Transaction { get; }
        Task CommitAsync();
        Task BeginTransactionAsync();
        Task RollbackAsync();
    }
}
