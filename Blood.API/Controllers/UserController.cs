using Blood.Models;
using Blood.Models.DbClient;
using Blood.Services.Authentication;
using Blood.Services.UserService;
using BloodRepositories.UserRepositories;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blood.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetallUser()
        {
            return Ok(await _userService.GetAllAsync());
        }


        [HttpPost("getbyName")]
        public async Task<IActionResult> GetbyName(UserNameDto user)
        {
            var user1 = await _userService.GetUserByname(user);
            return Ok(user1);
        }

        [AllowAnonymous]
        [HttpGet("GetUserId")]
        public async Task<IActionResult> GetUserId()
        {
            string id =  _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(id);
            return Ok(id);
        }

    }
}
