using Blood.Models;
using Blood.Models.DbClient;
using Blood.Services.Authentication;
using Blood.Services.UserService;
using BloodRepositories.UserRepositories;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateDto user)
        {
            var createuser = await _userService.CreateUserAsync(user);
            return Ok(createuser);
        }

        [HttpGet]

        public IActionResult GetallUser()
        {
            return Ok(_userService.GetAllAsync());
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogInDto loginDto)
        {
            var token = await _authenticationService.LoginAsync(loginDto);
            return Ok(token);
        }


        [HttpPost("getbyName")]
        public async Task<IActionResult> GetbyName(UserNameDto user)
        {
            var user1 =  _userService.GetUserByname(user);
            return Ok(user1);
        }
    }
}
