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
            return table.OrderByDescending(x => x.Rating).Take(10).ToList();
        }

        public IEnumerable<Movie> GetLongestMovies()
        {
            return table.OrderByDescending(x=>x.Duration).Take(10).ToList();
        }

        public IEnumerable<Movie> GetOldestMovies()
        {
            return table.OrderBy(x => x.ProductionYear.Year).Take(10).ToList();
        }

        public IEnumerable<Movie> GetNewestMovies()
        {
            return table.OrderByDescending(x => x.ProductionYear.Year).Take(10).ToList();
        }

        public IEnumerable<Movie> GetRelatedMovies(string genre, int count)
        {
            return table.Where(x=>x.Genre.Kind == genre).Take(count).ToList();
        }
    }
}
