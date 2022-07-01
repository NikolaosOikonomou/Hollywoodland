using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels
{
    public class ActorIndexViewModel
    {
     
        public IEnumerable<IGrouping<Country, Country>> Countries { get; set; }

        public IEnumerable<Actor> Actors { get; set; }

        public IEnumerable<string> GenrePlayed { get; set; } 


    }
}