using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie MovieDetails { get; set; }

        public IEnumerable<Movie> RelatedMovies { get; set; }
    }
}