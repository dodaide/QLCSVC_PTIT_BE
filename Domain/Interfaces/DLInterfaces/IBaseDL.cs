using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.DLInterfaces
{
    public interface IBaseDL<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Insert(T t);
        Task<int> Update(T t);
        Task<int> Delete<DeleteID>(DeleteID id);
    }
}
