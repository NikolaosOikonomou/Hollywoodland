using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core;
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
            Movies = new GenericRepository<Movie>(context);
        }

        public IGenericRepository<Movie> Movies { get; private set; }
       

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
