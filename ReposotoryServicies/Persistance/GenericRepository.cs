using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Persistance
{
    /// <summary>
    /// Implementing a Generic Repository.
    /// Therefore all the entities will have access to these methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : HollywoodEntity
    {
        private ApplicationDbContext db;
        private DbSet<T> table;

        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Add(T obj)
        {
            db.Entry(obj).State = EntityState.Added;
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T obj = table.Find(id);
            db.Entry(obj).State = EntityState.Deleted;
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
