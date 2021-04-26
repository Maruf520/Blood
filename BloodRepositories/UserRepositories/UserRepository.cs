using AutoMapper;
using Blood.Models;
using Blood.Models.DbClient;
using Dtos.UserDtos;
using MongoDB.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodRepositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _user;
        private readonly IMapper _mapper;

        public UserRepository(IDbClient dbClient, IMapper mapper)
        {
            _user = dbClient.GetUsersCollection();
            _mapper = mapper;
        }

        public async Task<GetUserDto> CreateAsync(UserCreateDto user)
        {
            var xx = _mapper.Map<User>(user);

            await _user.InsertOneAsync(xx);


            var usr = _mapper.Map<GetUserDto>(xx);

            return usr;

        }

        public List<User> AllUsersAsync()
        {

            return _user.Find(c => true).ToList();

        }
        public async Task<User> GetUserByName(string name)
        {
            var cursor = await _user.FindAsync(c => c.Email == name);
            var usr = await cursor.FirstOrDefaultAsync();
            if (usr == null)
            {
                throw new NotFoundException($"No user exists with name{usr}");
            }

            return usr;
        }

        public async Task<User> GetUserByname(string name)
        {
            return _user.Find(c => c.Email == name).FirstOrDefault();
        }


    }
}
