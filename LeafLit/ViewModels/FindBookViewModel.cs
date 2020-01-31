using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeafLit.Models;

namespace LeafLit.ViewModels
{
    public class FindBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Volumes volumes { get; set; }

    }
}
