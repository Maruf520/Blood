using Blood.Models;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.Authentication
{
    public  interface IAuthenticationService
    {
        Task<TokenDto> LoginAsync(UserLogInDto user);
    }
}
