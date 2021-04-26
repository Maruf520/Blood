using Blood.Models;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> CreateUserAsync(UserCreateDto user);
        Task<GetUserDto> GetUserByIdAsync(User user);
        Task<ServiceResponse<List<GetUserDto>>> GetAllAsync();
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
        Task<GetUserDto> GetUserByName(string name);
        Task<ServiceResponse<GetUserDto>> GetUserByname(UserNameDto name);
    }
}
