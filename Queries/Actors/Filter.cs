using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Actors
{
    public class Filter
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        //UnitOfWork unit;

        //public Filter()
        //{
        //    unit = new UnitOfWork(db);
        //}


        public void Filtering (List<Actor> actors, ActorQueries query)
        {
            if (!string.IsNullOrWhiteSpace(query.searchCountry))
            {
                actors = actors.Where(x => x.Country.ToString() == query.searchCountry).ToList();
            }
        }
    }
}
