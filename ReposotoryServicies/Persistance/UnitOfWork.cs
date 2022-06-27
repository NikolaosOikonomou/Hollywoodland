using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core;
using ReposotoryServicies.Core.Repositories;
using ReposotoryServicies.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            context = dbContext;
            Movies = new MovieRepository(context);
            Actors = new ActorRepository(context);
        }

        public IMovieRepository Movies { get; private set; }

        public IActorRepository Actors { get; private set; }
       

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
           context.Dispose();
        }
    }
}
