using LeafLit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.ViewModels
{
    public class RemoveUserBookViewModel
    {
        public int userId;
        public List<SelectedBook> removeBooks;

    }
    public class SelectedBook
    {
        public int bookId;
        public bool selected;
    }
}
