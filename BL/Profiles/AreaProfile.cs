using Application.DTOs.AreaDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class AreaProfile : Profile
{
    public AreaProfile()
    {
        CreateMap<Area, AreaGetAllDTO>();
        CreateMap<AreaInsertMasterDTO, Area>();
        CreateMap<AreaUpdateMasterDTO, Area>();
        CreateMap<AreaDeleteDTO, Area>();
    }
}