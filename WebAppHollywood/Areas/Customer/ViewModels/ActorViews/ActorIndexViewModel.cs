using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels
{
    public class ActorIndexViewModel
    {
     

        public IEnumerable<IGrouping<Country, Actor>> Countries { get; set; }

        public IEnumerable<Actor> Actors { get; set; }

        public IQueryable<IGrouping<Country, Actor>> ActorsByDecade { get; set; } 

       // public string HeaderTitle { get; set; }

    }
}