using Blood.Services.Authentication;
using Blood.Services.UserService;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        public AuthController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUserAsync(UserCreateDto user)
        {
            var createuser = await _userService.CreateUserAsync(user);
            return Ok(createuser);
        }


        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> LoginAsync(UserLogInDto userLogInDto)
        {


            var token = await _authenticationService.LoginAsync(userLogInDto);

            var usertoken = new TokenDto() { Bearer = token.Bearer };
            return Ok(usertoken);
        }
    }
}
