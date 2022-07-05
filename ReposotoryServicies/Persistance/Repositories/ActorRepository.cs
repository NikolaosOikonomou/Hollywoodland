using Entities.Models;
using Entities.SearchQueries;
using MyDatabase;
using RepositoryServicies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServicies.Persistance.Repositories
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

        /// <summary>
        /// Drawing all actors based on their date of birth.
        /// Displaying  Youngest actors first
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Actor> GetYoungestActors()
        {
            return table.OrderByDescending(x => x.DateOfBirth.Year).ToList();
        }

        /// <summary>
        /// Drawing all actors who are not alive
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Actor> GetActorsPastAway()
        {
            return table.Where(x => x.DateOfDeath.HasValue).OrderBy(x => x.FirstName).ToList();
        }

        /// <summary>
        /// Drawing actor's movies
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movie> GetActorMovies(int? id)
        {
            var movies = table.Find(id).Movies.ToList();
            return movies;
        }

        /// <summary>
        /// Grouping Actors by their country
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Country, Country>> GetActorsByCountry()
        {
            var group = from actor in table
                        group actor.Country by actor.Country into list
                        orderby list.Count() descending
                        select list;

            return group;
        }

        /// <summary>
        /// Grouping Actors by their Genre
        /// </summary>
        /// <returns></returns>
        public List<string> GetActorByGenre()
        {
            var group = table
                .SelectMany(x => x.Movies.Select(y => y.Genre != null ? y.Genre.Kind : "No Genre"))
                .Distinct().ToList();

            return group;
        }

        /// <summary>
        /// Grouping Actors by Decade they were born
        /// </summary>
        /// <returns></returns>
        public IOrderedQueryable<IGrouping<int, Actor>> GetActorsByDecade()
        {
            var group = from actor in table
                        group actor by (actor.DateOfBirth.Year /10 * 10) into decadesList
                        orderby decadesList.Key descending
                        select decadesList;
            return group;
        }

        public IEnumerable<Actor> GetRichestActors()
        {
           
            return table.OrderByDescending(x => x.Salary).ToList();
        }

        /// <summary>
        /// Filtering Actors based on their Genre,Country,Decade who were born
        /// </summary>
        /// <param name="filterSettings"></param>
        /// <returns></returns>
        public IEnumerable<Actor> Filtering(ActorFilterSettings filterSettings)
        {
            var actors = GetActorsOrderByAscending();
            IEnumerable<Actor> filteredActors = actors.ToList();

            //Filtering
            if (!string.IsNullOrEmpty(filterSettings.genresSearch))
            {
                filteredActors = filteredActors.Where(x => x.Movies.Select(y => y?.Genre?.Kind).Contains(filterSettings.genresSearch));
            }

            if (!string.IsNullOrEmpty(filterSettings.countriesSearch))
            {
                filteredActors = filteredActors.Where(x => x.Country.ToString().Contains(filterSettings.countriesSearch));
            }

            if (!(filterSettings.decadesSearch == null))
            {
                filteredActors = filteredActors.Where(x => x.DateOfBirth.Year >= filterSettings.decadesSearch && x.DateOfBirth.Year < filterSettings.decadesSearch + 10);
            }

            return filteredActors;
        }
    }
}
