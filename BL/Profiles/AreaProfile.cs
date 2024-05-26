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
}
