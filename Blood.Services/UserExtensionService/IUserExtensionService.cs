using Blood.Models;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.UserExtensionService
{
    public interface IUserExtensionService
    {
        string GetUserHashPassword(string password);
        bool CheckIfUserPasswordIsCorrect(string password, string hashpassword);
        TokenDto GenerateUserAccessToken(User user);
/*        Task<TokenDto> GenerateUserAccessToken(User users);*/
    }
}
