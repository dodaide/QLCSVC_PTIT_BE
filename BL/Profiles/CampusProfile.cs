using Application.DTOs.Campus;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class CampusProfile : Profile
{
    public CampusProfile()
    {
        CreateMap<Campus, CampusGetAllDTO>();
        CreateMap<CampusInsertDTO, Campus>();
        CreateMap<CampusUpdateDTO, Campus>();
        CreateMap<CampusDeleteDTO, Campus>();
    }
}