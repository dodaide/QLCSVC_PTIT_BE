using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.BLInterfaces
{
    public interface IBaseBL<T>
    {
        Task<int> Insert(T t);
        Task<int> Update(T t);
    }
}
