using Domain.Interfaces.DLInterfaces;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace DL
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbConnection? _connection = null;
        private DbTransaction? _transaction = null;
        private readonly string _connectionString;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public DbConnection Connection => _connection ??= new SqlConnection(_connectionString);

        public DbTransaction? Transaction => _transaction;

        public async Task BeginTransactionAsync()
        {
            _connection ??= new SqlConnection(_connectionString);

            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
            _transaction = await _connection.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            await DisposeAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            if (_connection != null)
            {
                await _connection.DisposeAsync();
                _connection = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
        }
    }
}
