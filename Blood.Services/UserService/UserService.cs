using AutoMapper;
using Blood.Models;
using Blood.Models.DbClient;
using Blood.Services.UserExtensionService;
using BloodRepositories.UserRepositories;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Security.Claims;

namespace Blood.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserExtensionService _userExtensionService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserExtensionService userExtensionService,IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userExtensionService = userExtensionService;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<ServiceResponse<GetUserDto>> CreateUserAsync(UserCreateDto user)
        {
            ServiceResponse<GetUserDto> ServiceResponse = new();
            var userTocreate = user;
            userTocreate.Password = _userExtensionService.GetUserHashPassword(user.Password);

            var createUser = await _userRepository.CreateAsync(userTocreate);
            var createdUser = _mapper.Map<GetUserDto>(createUser);
            ServiceResponse.Data = createdUser;
            return ServiceResponse;

        }

        public Task<bool> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }


        public async Task<ServiceResponse<List<GetUserDto>>> GetAllAsync()
        {
            ServiceResponse<List<GetUserDto>> response = new();

            var user =  _userRepository.AllUsersAsync();
          
            response.Data = (user.Select(c => _mapper.Map<GetUserDto>(c)).ToList());
            return response;
        }

        public Task<GetUserDto> GetUserByIdAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserDto> GetUserByName(string name)
        {
            var x = await _userRepository.GetUserByName(name);

            var user = _mapper.Map<GetUserDto>(x);
            return user;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserByname(UserNameDto name)
        {
            ServiceResponse<GetUserDto> response = new();
            var user = await  _userRepository.GetUserByname(name.Email);
            if(user != null)
            {
                var userByName =  _mapper.Map<GetUserDto>(user);
                response.Data = userByName;
            }
            else
            {
                response.Success = false;
                response.Message = "User Not Found!!";
            }
            return response;
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
/*
      public string GetUserId()
        {
            var id = _httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return id;
        }*/
    }
}