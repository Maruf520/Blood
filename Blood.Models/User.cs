using Blood.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public BloodGroup bloodGroup { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public DateTime LastDateOfDonation { get; set; }
        public string Address { get; set; }

    }
}
