using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHollywood.Areas.Customer.ViewModels
{
    public class MovieIndexViewModel
    {
        public IEnumerable<Movie> AllMovies { get; set; }

        public IEnumerable<Movie> BestMovies { get; set; }

        public IEnumerable<Movie> RelatedMovies { get; set; }

        public IEnumerable<Movie> LongestMovies { get; set; }

        public IEnumerable<Movie> OldestMovies { get; set; }

        public IEnumerable<Movie> NewestMovies { get; set; }
    }
}