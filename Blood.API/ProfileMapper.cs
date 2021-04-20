using AutoMapper;
using Blood.Models;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.API
{
    public class ProfileMapper: Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<User, UserLogInDto>();
            CreateMap<User, UserNameDto>();
            CreateMap<GetUserDto, UserNameDto>();
            CreateMap<User, UserNameDto>();
            CreateMap<UserNameDto, GetUserDto>();
        }
    }
}
