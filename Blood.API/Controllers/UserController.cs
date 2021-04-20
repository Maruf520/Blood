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
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetallUser()
        {
            return Ok(_userService.GetAllAsync());
        }


        [HttpPost("getbyName")]
        public async Task<IActionResult> GetbyName(UserNameDto user)
        {
            var user1 = await _userService.GetUserByname(user);
            return Ok(user1);
        }
    }
}
