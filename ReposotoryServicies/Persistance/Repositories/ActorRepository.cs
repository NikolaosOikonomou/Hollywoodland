using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Persistance.Repositories
{
    internal class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Actor> GetActorsOrderByAscending()
        {
            return table.OrderBy(x => x.LastName).ToList();
        }

        public IEnumerable<Actor> GetYoungestActors()
        {
            return table.OrderByDescending(x => x.DateOfBirth.Year).ToList();
        }

        public IEnumerable<Actor> GetOldestActors()
        {
            return table.OrderBy(x => x.DateOfBirth.Year).ToList();
        }

        public IEnumerable<Movie> GetActorMovies(int? id)
        {
            var movies = table.Find(id).Movies.ToList().Take(5);
            return movies;
        }

        public IEnumerable<IGrouping<Country, Actor>> GetActorsByCountry()
        {
            var group = from actor in table
                        group actor by actor.Country into lista
                        select lista;

            return group;
        }


    
    }
}
