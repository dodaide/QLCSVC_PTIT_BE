using Application.DTOs.AreaDTO;
using Application.DTOs.AreaCampusDTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class AreaCampusProfile : Profile
    {
        public AreaCampusProfile()
        {
            CreateMap<AreaCampus, AreaCampusGetDetailsDTO>();
            CreateMap<AreaCampusSaveDTO, AreaCampus>();
        }
    }
}
