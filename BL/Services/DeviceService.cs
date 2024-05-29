using System.Data;
using AutoMapper;
using Dapper;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Domain.Interfaces.InfrastructureInterfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services;

public class DeviceService : BaseService<Device, Device>, IDeviceService
{

    public DeviceService(IBaseRepo<Device> iBaseRepo, IBaseRepo<Device> iBaseDetailRepo, IUnitOfWork iUnitOfWork,
        IMapper iMapper, IMemoryCache iMemoryCache) : base(iBaseRepo, iBaseDetailRepo, iUnitOfWork, iMapper,
        iMemoryCache)
    {
        
    }

    public async Task<IEnumerable<DTO>> GetDevices<DTO>(int pageNumber, int pageSize, int? campusID = null)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", pageNumber);
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@CampusID", campusID);

        var devices = await baseRepo.GetAllPagination(parameters);
        var resDto = mapper.Map<IEnumerable<DTO>>(devices);
        return resDto;
    }
}