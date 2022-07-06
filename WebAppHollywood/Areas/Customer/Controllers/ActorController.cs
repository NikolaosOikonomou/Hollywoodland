using Entities.Models;
using Entities.SearchQueries;
using RepositoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppHollywood.Areas.Customer.ViewModels;
using WebAppHollywood.Areas.Customer.ViewModels.ActorViews;


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


        public ActionResult Index(ActorFilterSettings filterSettings, string sortOptions)
        {
            var filteredActors = unit.Actors.Filtering(filterSettings);

            switch (sortOptions)
            {
                case "featured": filteredActors = unit.Actors.GetActorsOrderByAscending(); break;
                case "youngestAsc": filteredActors = unit.Actors.GetYoungestActors(); break;
                case "notAlive": filteredActors = unit.Actors.GetActorsPastAway(); break;
                case "richestAsc": filteredActors = unit.Actors.GetRichestActors(); break;
                default:/* filteredActors = unit.Actors.GetActorsOrderByAscending();*/ break;
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