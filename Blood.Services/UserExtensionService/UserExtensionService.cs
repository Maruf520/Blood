using Blood.Models;
using Dtos.UserDtos;
using Enyim.Caching.Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.UserExtensionService
{
    public class UserExtensionService : IUserExtensionService
    {

        public bool CheckIfUserPasswordIsCorrect(string password, string hashpassword)
        {
            return GetUserHashPassword(password) == hashpassword;
        }

        public TokenDto GenerateUserAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var charCount = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            var key = Encoding.UTF8.GetBytes(charCount);

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDiscriptor);

            return new TokenDto { Bearer = tokenHandler.WriteToken(token) };
        }

        public string GenerateUserAccessToken(string token)
        {
            throw new NotImplementedException();
        }

        public string GetUserHashPassword(string password)
        {
            var salt = Encoding.ASCII.GetBytes("This is hidden");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2

                (
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));
            return hashed;
        }
    }
}
