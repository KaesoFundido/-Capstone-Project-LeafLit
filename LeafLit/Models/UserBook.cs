using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    public class UserBook
    {
        public int BookID { get; set; }

        public Book book { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
    }
}
