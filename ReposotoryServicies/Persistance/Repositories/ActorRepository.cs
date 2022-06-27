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

        public IEnumerable<Actor> GetMoviesOrderByAscending()
        {
            return table.OrderBy(x => x.LastName).ToList();
        }

        public IEnumerable<Actor> GetNewestActors()
        {
            return table.OrderByDescending(x => x.DateOfBirth.Year).ToList();
        }

        public IEnumerable<Actor> GetOldestActors()
        {
            return table.OrderBy(x => x.DateOfBirth.Year).ToList();
        }
    }
}
