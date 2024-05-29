using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Domain.Interfaces.InfrastructureInterfaces;
using Microsoft.Extensions.Configuration;

namespace Repo;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private DbConnection? _connection;

    public UnitOfWork(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
    }

    public DbConnection Connection => _connection ??= new SqlConnection(_connectionString);

    public DbTransaction? Transaction { get; private set; }

    public async Task BeginTransactionAsync()
    {
        _connection ??= new SqlConnection(_connectionString);

        if (_connection.State != ConnectionState.Open) await _connection.OpenAsync();
        Transaction = await _connection.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (Transaction != null) await Transaction.CommitAsync();
        await DisposeAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async ValueTask DisposeAsync()
    {
        if (Transaction != null)
        {
            await Transaction.DisposeAsync();
            Transaction = null;
        }

        if (_connection != null)
        {
            await _connection.DisposeAsync();
            _connection = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (Transaction != null) await Transaction.RollbackAsync();
        await DisposeAsync();
    }
}