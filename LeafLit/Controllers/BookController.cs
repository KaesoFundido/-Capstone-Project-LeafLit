using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeafLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LeafLit.Data;
using LeafLit.Models;



namespace LeafLit.Controllers
{
    public class BookController : Controller
    {
        private readonly GoogleBookAPI googleBookAPI;

        private BookDbContext DbContext;

        public BookController(BookDbContext dbContext)
        {
            GoogleBookAPI api = new GoogleBookAPI();
            api.Initialize();
            googleBookAPI = api;

            DbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FindBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindBook(FindBookViewModel findbook) 
        {
            if (findbook.ISBN!=null || findbook.Title!=null||findbook.Author!=null)
            {
                string query = "volumes?q=";
                if (findbook.ISBN != null)
                {
                    query += "isbn:" + findbook.ISBN;
                }
                if (findbook.Title != null)
                {
                    if (query == "volumes?q=")
                    {
                        query += "intitle:" + findbook.Title;
                    }
                    else
                    {
                        query += "+intitle:" + findbook.Title;
                    }
                }
                if (findbook.Author != null)
                {
                    if (query == "volumes?q=")
                    {
                        query += "inauthor:" + findbook.Author;
                    }
                    else
                    {
                        query += "+inauthor:" + findbook.Author;
                    }
                }
                findbook.volumes = googleBookAPI.GetVolumes(query);
                if(findbook.volumes.kind == null )
                {
                    //Data did not get pulled properly from the database
                }

                ViewData["SearchResults"] = findbook.volumes;
                return View("SearchResults", findbook);
            }
            return Redirect("/Book/FindBook");
        }

        [HttpPost]
        public IActionResult AddBooksToShelf(FindBookViewModel Addbooks)
        {
            foreach (Volume vol in Addbooks.volumes.items)
            {
                if (vol.selected)
                {
                    Book book = new Book(vol);
                    var bookInDb = DbContext.Books.Where(b => b.Author == book.Author && b.ISBN_10 == book.ISBN_10 && b.ISBN_13 == book.ISBN_13 && b.Title == book.Title);

                    if (bookInDb.Count() > 0)
                    {
                        UserBook userBook = new UserBook();
                        userBook.BookID = bookInDb.First().BookID;
                        userBook.UserID = DbContext.Users.First().UserID;
                        var bookOnShelf = DbContext.UserBooks.Where(x => x.BookID == userBook.BookID && x.UserID == userBook.UserID);
                        if(bookOnShelf.Count() == 0)
                        {
                            DbContext.UserBooks.Add(userBook);
                            DbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        DbContext.Books.Add(book);
                        DbContext.SaveChanges();
                        UserBook userBook = new UserBook();
                        userBook.BookID = book.BookID;
                        userBook.UserID = DbContext.Users.First().UserID;
                        DbContext.UserBooks.Add(userBook);
                        DbContext.SaveChanges();
                    }
                }
            }
            //todo: redirect to shelf of user
            return Redirect("/Shelf/UserShelf?userId=" + DbContext.Users.First().UserID);
        }
    }
}
