using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeafLit.Data;
using LeafLit.Models;
using LeafLit.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeafLit.Controllers
{
    public class ShelfController : Controller
    {
        private BookDbContext DbContext;

        public ShelfController(BookDbContext dbContext)
        {
            DbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            AllUserShelvesViewModel allUsersVM = new AllUserShelvesViewModel();
            allUsersVM.users = DbContext.Users.Where(x => x.UserID == x.UserID).ToList();
            return View(allUsersVM);
        }

        public IActionResult UserShelf(int userId)
        {
            SingleUserShelfViewModel singleUserVM = new SingleUserShelfViewModel();
            singleUserVM.user = DbContext.Users.Where(x => x.UserID == userId).First();
            if(singleUserVM.user.Username == null)
            {
                return Redirect("/Shelf");
            }
            List<UserBook> userShelf = DbContext.UserBooks.Where(x => x.UserID == userId).ToList();
            List<Book> shelf = new List<Book>();
            foreach(UserBook ub in userShelf)
            {
                shelf.Add(DbContext.Books.Where(x => x.BookID == ub.BookID).First());
            }
            singleUserVM.shelf = shelf;
            List<UserBookRating> userRatingShelf = DbContext.UserBookRatings.Where(x => x.UserID == userId).ToList();
            List<UserBookRating> userBookRatings = new List<UserBookRating>();
            foreach (UserBookRating ub in userRatingShelf)
            {
                userBookRatings.Add(DbContext.UserBookRatings.Where(x => x.BookID == ub.BookID && x.UserID == ub.UserID).First());
            }
            singleUserVM.ratings = userBookRatings;
            //need: a viewmodel that shows the userbooks (shelf) for a given user
            //need: a model to use with the viewmodel
            return View(singleUserVM);
        }
        public IActionResult RemoveFromShelf(int userid , int bookid)
        {
            
                if (userid != 0 && bookid != 0)
                {
                //var bookOnShelf = DbContext.UserBooks.Where(x => x.BookID == book.BookID && x.UserID == singleUserVM.user.UserID).First();
                    var bookOnShelf = DbContext.UserBooks.Single(b => b.BookID == bookid && b.UserID == userid);
                    DbContext.Remove(bookOnShelf);
                    DbContext.SaveChanges();
                }
          
            return Redirect("/Shelf/UserShelf?userId=" + 1);
            //return Redirect("/Shelf/UserShelf?userId=" + singleUserVM.user.UserID);
        }

        public IActionResult RateBook(int userid, int bookid, int rating)
        {
            if(rating < 1 || rating > 5)
            {
                rating = 1;
            }
            if (userid != 0 && bookid != 0)
            {
                var ratedBookOnShelf = DbContext.UserBookRatings.Where(b => b.BookID == bookid && b.UserID == userid);
                if(ratedBookOnShelf.Count() == 0)
                {
                    UserBookRating ubrating = new UserBookRating();
                    ubrating.BookID = bookid;
                    ubrating.UserID = userid;
                    ubrating.Rating = rating;
                    DbContext.UserBookRatings.Add(ubrating);
                }
                else
                {
                    ratedBookOnShelf.First().Rating = rating;
                }
                DbContext.SaveChanges();
            }

            return Redirect("/Shelf/UserShelf?userId=" + 1);
            //return Redirect("/Shelf/UserShelf?userId=" + singleUserVM.user.UserID);
        }
    }
}
