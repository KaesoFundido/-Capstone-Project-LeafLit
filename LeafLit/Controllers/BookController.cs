using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeafLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LeafLit.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeafLit.Controllers
{
    public class BookController : Controller
    {
        private readonly GoogleBookAPI googleBookAPI;

        public BookController()
        {
            GoogleBookAPI api = new GoogleBookAPI();
            api.Initialize();
            googleBookAPI = api;
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
            findbook.volumes = googleBookAPI.GetVolumes("volumes?q=isbn:" + findbook.ISBN );
            return View("SearchResults",findbook);
        }
    }
}
