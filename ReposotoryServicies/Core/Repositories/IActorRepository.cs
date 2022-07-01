using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Core.Repositories
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsOrderByAscending();

        IEnumerable<Movie> GetActorMovies(int? id);

        IEnumerable<Actor> GetOldestActors();

        IEnumerable<Actor> GetYoungestActors();

        IEnumerable<IGrouping<Country, Actor>> GetActorsByCountry();
    }
}
