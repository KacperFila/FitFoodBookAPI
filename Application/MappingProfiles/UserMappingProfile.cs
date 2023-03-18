using Application.Users.Dtos;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}