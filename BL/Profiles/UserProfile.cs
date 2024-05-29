using Application.DTOs.AreaDTO;
using Application.DTOs.DeviceDTO;
using Application.DTOs.UserDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}