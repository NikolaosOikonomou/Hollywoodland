using Entities.Models;
using Entities.SearchQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RepositoryServicies.Core.Repositories
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsOrderByAscending();

        IEnumerable<Movie> GetActorMovies(int? id);

        IEnumerable<Actor> GetActorsPastAway();

        IEnumerable<Actor> GetYoungestActors();

        IEnumerable<IGrouping<Country, Country>> GetActorsByCountry();

        List<string> GetActorByGenre();

        IOrderedQueryable<IGrouping<int, Actor>> GetActorsByDecade();

        IEnumerable<Actor> Filtering(ActorFilterSettings filterSettings);

        IEnumerable<Actor> GetRichestActors();



    }
}
