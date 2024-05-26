using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InfrastructureInterfaces
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Insert(T t);
        Task<int> Update(T t);
        Task<int> Delete(T t);
        Task<IEnumerable<T>> GetDetailsByID(int id, string masterName);
    }
}
