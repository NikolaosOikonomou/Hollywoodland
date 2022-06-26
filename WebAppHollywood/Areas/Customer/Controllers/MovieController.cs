using Entities.Models;
using ReposotoryServicies.Core;
using ReposotoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHollywood.Areas.Customer.ViewModels;
using WebAppHollywood.Models;

namespace WebAppHollywood.Areas.Customer.Controllers
{
    public class MovieController : Controller
    {
        private MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        private UnitOfWork unit;

        public MovieController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: Customer/Movie
        public ActionResult Index()
        {
            MovieIndexViewModel vm = new MovieIndexViewModel()
            {
                AllMovies = unit.Movies.GetAll()
            };

            return View(vm);
        }

        public ActionResult Details()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult DisplayMovieCards(List<Movie> movies, string headerMessage)
        {
            DisplayMovieCardsViewModel vm = new DisplayMovieCardsViewModel()
            {
                Movies = movies,
                HeaderTitle = headerMessage
            };
            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}