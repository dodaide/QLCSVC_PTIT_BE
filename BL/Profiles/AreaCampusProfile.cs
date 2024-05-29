using Application.DTOs.AreaCampusDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class AreaCampusProfile : Profile
{
    public AreaCampusProfile()
    {
        CreateMap<AreaCampus, AreaCampusGetDetailsDTO>();
        CreateMap<AreaCampusSaveDTO, AreaCampus>();
    }
}