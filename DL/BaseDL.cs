using Dapper;
using Domain.Interfaces.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Enums.Action;

namespace DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        protected readonly IUnitOfWork unitOfWork;
        protected Action action;

        public BaseDL(IUnitOfWork IUnitOfWork)
        {
            unitOfWork = IUnitOfWork;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            action = Action.GetAll;
            var storeName = GetProcName();
            var res = await unitOfWork.Connection.QueryAsync<T>(storeName, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Insert(T t)
        {
            action = Action.Insert;
            var storeName = GetProcName();
            var res = await unitOfWork.Connection.ExecuteAsync(storeName, t, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Update(T t)
        {
            action = Action.Update;
            var storeName = GetProcName();
            var res = await unitOfWork.Connection.ExecuteAsync(storeName, t, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Delete<DeleteID>(DeleteID id)
        {
            action = Action.Delete;
            var storeName = GetProcName();
            var res = await unitOfWork.Connection.ExecuteAsync(storeName, id, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        protected virtual string GetProcName()
        {
            return $"Proc_{typeof(T).Name}_{action.ToString()}";
        }
    }
}
