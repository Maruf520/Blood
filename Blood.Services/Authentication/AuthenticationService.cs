using Blood.Models;
using Blood.Services.UserExtensionService;
using BloodRepositories.UserRepositories;
using Dtos.UserDtos;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserExtensionService _userExtensionService;
        public AuthenticationService(IUserRepository userRepository, IUserExtensionService userExtensionService)
        {
            _userRepository = userRepository;
            _userExtensionService = userExtensionService;
        }
        public async Task<TokenDto> LoginAsync(UserLogInDto loginDto)
        {
            var users = await _userRepository.GetUserByName(loginDto.Email);
            if (users == null)
            {
                throw new UnauthorizedException("No user found with this name");
            }
            if (!_userExtensionService.CheckIfUserPasswordIsCorrect(loginDto.Password, users.Password))
            {
                throw new UnauthorizedException("Incorrect password");
            }
            return _userExtensionService.GenerateUserAccessToken(users);
        }
    }
}
