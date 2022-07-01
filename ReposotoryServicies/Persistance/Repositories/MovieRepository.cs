using Entities.Models;
using MyDatabase;
using RepositoryServicies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServicies.Persistance
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

        public IEnumerable<Movie> GetRelatedMovies(int? id, int count)
        {
            var movie = table.Find(id);
            return table.Where(x => x.Genre.Kind == movie.Genre.Kind && x.MovieId != movie.MovieId).ToList();
        }
    }
}
