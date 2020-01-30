using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.ViewModels
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Rating { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public int GenreID { get; set; }

        public AddBookViewModel()
        {
        }
    }
}
