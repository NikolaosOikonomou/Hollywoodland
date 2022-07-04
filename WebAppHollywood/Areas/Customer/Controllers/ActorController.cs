using Entities.Models;
using RepositoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppHollywood.Areas.Customer.ViewModels;
using WebAppHollywood.Areas.Customer.ViewModels.ActorViews;
using WebAppHollywood.FilterServices;

namespace WebAppHollywood.Areas.Customer.Controllers
{
    public class ActorController : Controller
    {
        private MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();

        private UnitOfWork unit;

        public ActorController()
        {
            unit = new UnitOfWork(db);
        }


        public ActionResult Index(string genresSearch, string countriesSearch, int? decadesSearch)
        {
            var actors = unit.Actors.GetAll().OrderBy(x => x.FirstName);
            IEnumerable<Actor> filteredActors = actors.ToList();

            //Filtering
            if (!string.IsNullOrEmpty(genresSearch))
            {
                filteredActors = filteredActors.Where(x => x.Movies.Select(y => y?.Genre?.Kind).Contains(genresSearch));
            }

            if (!string.IsNullOrEmpty(countriesSearch))
            {
                filteredActors = filteredActors.Where(x => x.Country.ToString().Contains(countriesSearch));
             
            }

            if (!(decadesSearch == null))
            {
                filteredActors = filteredActors.Where(x => x.DateOfBirth.Year >= decadesSearch && x.DateOfBirth.Year < decadesSearch + 10);
            }


            ActorIndexViewModel vm = new ActorIndexViewModel()
            {
                Actors = filteredActors,
                Countries = unit.Actors.GetActorsByCountry(),
                GenrePlayed = unit.Actors.GetActorByGenre(),
                Decades = unit.Actors.GetActorsByDecade()
            };

            return View(vm);

        }


        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var actor = unit.Actors.GetById(id);
            if (actor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var actorMovies = unit.Actors.GetActorMovies(id);
            ActorDetailsViewModel vm = new ActorDetailsViewModel()
            {
                Actor = actor,
                ActorMovies = actorMovies
            };

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult DisplayActorMovieCards(List<Movie> movies, string headerTitle)
        {

            DisplayActorCardsViewModel vm = new DisplayActorCardsViewModel()
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