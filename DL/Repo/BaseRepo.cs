using Dapper;
using Domain.Enums;
using Domain.Interfaces.InfrastructureInterfaces;
using System.Data;

namespace Infrastructure.Repo
{
    public class BaseRepo<T> : IBaseRepo<T>
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseRepo(IUnitOfWork IUnitOfWork)
        {
            unitOfWork = IUnitOfWork;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var storeName = GetProcName(DBAction.GetAll);
            var res = await unitOfWork.Connection.QueryAsync<T>(storeName, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Insert(T t)
        {
            var storeName = GetProcName(DBAction.Insert);
            var parameters = await GetStoredProcedureParameters(storeName, t);
            var res = await unitOfWork.Connection.ExecuteScalarAsync<int>(storeName, parameters, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Update(T t)
        {
            var storeName = GetProcName(DBAction.Update);
            var parameters = await GetStoredProcedureParameters(storeName, t);
            var res = await unitOfWork.Connection.ExecuteAsync(storeName, parameters, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Delete(T t)
        {
            var storeName = GetProcName(DBAction.Delete);
            var parameters = await GetStoredProcedureParameters(storeName, t);
            var res = await unitOfWork.Connection.ExecuteAsync(storeName, parameters, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }
        public async Task<IEnumerable<T>> GetDetailsByID(int id, string masterName)
        {
            var parameters = new DynamicParameters();
            parameters.Add($"@{masterName}ID", id);
            var storeName = GetProcName(DBAction.GetDetails);
            var res = await unitOfWork.Connection.QueryAsync<T>(storeName, parameters, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return res;
        }

        protected virtual string GetProcName(DBAction action)
        {
            return $"Proc_{typeof(T).Name}_{action}";
        }

        protected virtual async Task<DynamicParameters> GetStoredProcedureParameters(string storeName, T t)
        {
            var procParam = await unitOfWork.Connection.QueryAsync<string>("Proc_Get_Store_Params", new { StoredProcedureName = storeName }, transaction: unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            var parameters = new DynamicParameters();

            foreach (var prop in typeof(T).GetProperties())
            {
                var propName = "@" + prop.Name;
                if (procParam.Contains(propName))
                {
                    parameters.Add(propName, prop.GetValue(t));
                }
            }
            return parameters;
        }
    }
}
