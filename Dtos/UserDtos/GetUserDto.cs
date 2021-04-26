using Blood.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos
{
    public class GetUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public BloodGroup bloodGroup { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastDateOfDonation { get; set; }
        public string Address { get; set; }


    }
}
