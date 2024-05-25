using System.Data;
using Dapper;
using Domain.Entities;
using Domain.Interfaces.DLInterfaces;

namespace DL;

public class UserDL
{
    private readonly IUnitOfWork unitOfWork;

    public UserDL(IUnitOfWork IUnitOfWork)
    {
        unitOfWork = IUnitOfWork;
    }
    
    public async Task<User> GetUserAsync(string username)
    {
        var storeName = "Proc_GetUserName_Password";
        var res = await unitOfWork.Connection.QueryFirstOrDefaultAsync<User>(storeName, new { Username = username}, commandType: CommandType.StoredProcedure);
        return res;
    }
}