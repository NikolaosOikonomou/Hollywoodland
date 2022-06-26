using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Persistance
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        

        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Movie> GetMoviesOrderByAscending()
        {
            return table.OrderBy(x => x.Title).ToList();
        }


        public IEnumerable<Movie> GetBestMovies()
        {
            return table.OrderBy(x => x.Rating).Take(10).ToList();
        }
    }
}
