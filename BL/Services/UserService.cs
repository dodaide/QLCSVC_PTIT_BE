using System.Data;
using AutoMapper;
using Dapper;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Domain.Interfaces.InfrastructureInterfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services;

public class UserService : BaseService<User, User>, IUserService
{

    public UserService(IBaseRepo<User> iBaseRepo, IBaseRepo<User> iBaseDetailRepo, IUnitOfWork iUnitOfWork,
        IMapper iMapper, IMemoryCache iMemoryCache) : base(iBaseRepo, iBaseDetailRepo, iUnitOfWork, iMapper,
        iMemoryCache)
    {
        
    }
    
    public async Task<IEnumerable<DTO>> GetUsers<DTO>(int pageNumber, int pageSize, string? keyword = null)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", pageNumber);
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@Keyword", keyword);

        var devices = await baseRepo.GetAllPagination(parameters);
        var resDto = mapper.Map<IEnumerable<DTO>>(devices);
        return resDto;
    }
}