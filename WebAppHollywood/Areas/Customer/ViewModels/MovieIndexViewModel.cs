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
    }
}