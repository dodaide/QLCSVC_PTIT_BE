using Application.DTOs.AreaDTO;
using Application.DTOs.Campus;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CampusProfile : Profile
    {
        public CampusProfile()
        {
            CreateMap<Campus, CampusGetAllDTO>();
        }
    }
}
