using Dapper;

namespace Domain.Interfaces.InfrastructureInterfaces;

public interface IBaseRepo<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAllPagination( DynamicParameters? parameters);
    Task<int> Insert(T t);
    Task<int> Update(T t);
    Task<int> Delete(T t);
    Task<IEnumerable<T>> GetDetailsByID(int id, string masterName);
    Task<IEnumerable<T>?> GetDetailByID(DynamicParameters? parameters);
}