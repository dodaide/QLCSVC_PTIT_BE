using Domain.Entities;
using Domain.Interfaces.ApplicationInterfaces;

namespace Domain.Interfaces.AppicationInterfaces;

public interface IDeviceService : IBaseService<Device, Device>
{
    Task<IEnumerable<DTO>> GetDevices<DTO>(int pageNumber, int pageSize, int? campusID = null);
}