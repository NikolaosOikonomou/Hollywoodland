using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }

        public IEnumerable<Movie> ActorMovies { get; set; }
    }
}