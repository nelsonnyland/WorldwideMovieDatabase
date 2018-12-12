using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldwideMovieDatabase.Models;

namespace WorldwideMovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(MovieDb.GetAllMovies(db));
        }
    }
}