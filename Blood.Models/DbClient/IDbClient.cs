using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Models.DbClient
{
    public interface IDbClient
    {
        IMongoCollection<User> GetUsersCollection();
    }
}
