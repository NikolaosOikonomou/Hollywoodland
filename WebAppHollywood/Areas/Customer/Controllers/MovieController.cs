using Entities.Models;
using ReposotoryServicies.Core;
using ReposotoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                AllMovies = unit.Movies.GetMoviesOrderByAscending(),
                BestMovies = unit.Movies.GetBestMovies(),
                LongestMovies = unit.Movies.GetLongestMovies(),
                NewestMovies = unit.Movies.GetNewestMovies(),
                OldestMovies = unit.Movies.GetOldestMovies()
            };

            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = unit.Movies.GetById(id);
            if (movie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.RelatedMovies = unit.Movies.GetRelatedMovies(movie.Genre.Kind, 5);
            return View(movie);
        }

        [ChildActionOnly]
        public ActionResult DisplayMovieCards(List<Movie> movies, string headerTitle)
        {
            DisplayMovieCardsViewModel vm = new DisplayMovieCardsViewModel()
            {
                Movies = movies,
                HeaderTitle = headerTitle
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