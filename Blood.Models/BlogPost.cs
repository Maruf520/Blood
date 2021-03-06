using Blood.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood.Models
{
    public class BlogPost
    {
        public string Id { get; set; }
        public string PostBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Location { get; set; }
        public Enum BloodGroup { get; set; }
        public int Quantity { get; set; }
        public DateTime NeededAt { get; set; }
        public  List<BlogComment> Comments{ get; set; }

    }
}
