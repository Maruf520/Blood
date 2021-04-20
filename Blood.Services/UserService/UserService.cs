using AutoMapper;
using Blood.Models;
using Blood.Models.DbClient;
using Blood.Services.UserExtensionService;
using BloodRepositories.UserRepositories;
using Dtos.UserDtos;
using MongoDB.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserExtensionService _userExtensionService;

        private readonly IMapper _mapper;
        public UserService(IUserExtensionService userExtensionService, IUserRepository userRepository, IMapper mapper)
        {
            _userExtensionService = userExtensionService;
            _userRepository = userRepository;
                _mapper = mapper;
        }
        public async Task<GetUserDto> CreateUserAsync(UserCreateDto user)
        {
            var userTocreate = user;
            userTocreate.Password = _userExtensionService.GetUserHashPassword(user.Password);

           var createUser =  await _userRepository.CreateAsync(userTocreate);
            var us = _mapper.Map<GetUserDto>(createUser);
            return us;

        }

        public Task<bool> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserNameDto>> GetAllAsync()
        {
            var allusers = await _userRepository.AllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserNameDto>>(allusers);
            return users;
        }


        public Task<GetUserDto> GetUserByIdAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserDto> GetUserByName(string name)
        {
            var x = await _userRepository.GetUserByName(name);

            var user =  _mapper.Map<GetUserDto>(x);
            return user;
        }

        public async Task<GetUserDto> GetUserByname(UserNameDto name)
        {
            var user =  _userRepository.GetUserByname(name.Email);
            var x =  _mapper.Map<GetUserDto>(user);
            return x;
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}
