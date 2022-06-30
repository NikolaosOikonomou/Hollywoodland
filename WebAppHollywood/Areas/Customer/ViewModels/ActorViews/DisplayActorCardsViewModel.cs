using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels.ActorViews
{
    public class DisplayActorCardsViewModel
    {

        public IEnumerable<Movie> Movies { get; set; }

        public string HeaderTitle { get; set; }
    }
}