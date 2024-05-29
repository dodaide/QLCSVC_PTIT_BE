using Domain.Entities;
using Domain.Interfaces.ApplicationInterfaces;

namespace Domain.Interfaces.AppicationInterfaces;

public interface IUserService : IBaseService<Device, Device>
{
    Task<IEnumerable<DTO>> GetUsers<DTO>(int pageNumber, int pageSize, string? keyword = null);
}