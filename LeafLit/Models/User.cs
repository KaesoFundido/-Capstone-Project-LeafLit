using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    public class User
    {
        public string Username {get; set;}
        public int UserID { get; set; }
        private string Password { get; set; }
        private string Validation { get; set; }
    }
}
