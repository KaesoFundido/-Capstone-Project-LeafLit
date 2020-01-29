using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    public class Book
    {
        /// <summary>
        /// this will represent the data parced from the .json from GoogleBookAPI
        /// </summary>
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string ISBN { get; set; }

        public IList<UserBook> Shelves { get; set; }
        public IList<BookGenre> Genres { get; set; }
        
    }
}
