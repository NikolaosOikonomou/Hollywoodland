using MyDatabase;
using ReposotoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Actors
{
    public class ActorQueries
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UnitOfWork unit;

        public ActorQueries()
        {
            unit = new UnitOfWork(db);
        }

        public string searchCountry { get; set; }

    }
}
