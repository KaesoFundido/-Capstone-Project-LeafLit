using LeafLit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.ViewModels
{
    public class SingleUserShelfViewModel
    {
        public User user;
        public List<Book> shelf;
        public List<UserBookRating> ratings;
    }
}
