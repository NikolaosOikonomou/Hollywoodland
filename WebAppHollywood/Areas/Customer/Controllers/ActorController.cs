using Entities.Models;
using ReposotoryServicies.Persistance;
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


        public ActionResult Index(string searchCountry)
        {
            ViewBag.currentCountry = searchCountry;
           
            ActorIndexViewModel vm = new ActorIndexViewModel()
            {

                Actors = unit.Actors.GetActorsOrderByAscending(),
                Countries = unit.Actors.GetActorsByCountry(),
                 
            };
            if (searchCountry == null) { return View(vm); }
            if (!(searchCountry == "All"))
            {

                ActorsFilterByCountry(vm, searchCountry);
            }
           
           

            return View(vm);

        }

        public void ActorsFilterByCountry(ActorIndexViewModel vm, string country)
        {
            var actors = from actor in vm.Actors
                         where actor.Country.ToString() == country
                         select actor;
            vm.Actors = actors;
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