using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    // this is a many-to-many join table between Book and Genre. 
    public class BookGenre
    {
        public int BookID { get; set; }
        public Book Book { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }

    }
}
