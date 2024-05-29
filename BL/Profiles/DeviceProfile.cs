using Application.DTOs.AreaDTO;
using Application.DTOs.DeviceDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, DeviceDTO>();
        CreateMap<DeviceDTO, Device>();
    }
}