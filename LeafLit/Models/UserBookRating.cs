using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    public class UserBookRating
    {
        public int Rating { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public User user { get; set; }
        public Book book { get; set; }
    }
}
