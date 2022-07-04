using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHollywood.Areas.Customer.ViewModels;

namespace WebAppHollywood.FilterServices
{
    public class ActorFilter
    {
        /// <summary>
        /// FIlltering Actors by Country.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="country"></param>
        public void ActorsByCountry(ActorIndexViewModel vm, string country)
        {
            var actors = from actor in vm.Actors
                         where actor.Country.ToString() == country
                         select actor;
            vm.Actors = actors;
        }

        public string searchCountry { get; set; }
    }
}