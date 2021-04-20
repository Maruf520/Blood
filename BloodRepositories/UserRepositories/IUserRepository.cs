using Blood.Models;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodRepositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<GetUserDto> CreateAsync(UserCreateDto user);
        Task<IEnumerable<UserNameDto>> AllUsersAsync();
        Task<User> GetUserByName(string name);
        User GetUserByname(string name);

    }
}
