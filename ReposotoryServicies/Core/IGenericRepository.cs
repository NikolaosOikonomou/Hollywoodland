using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace RepositoryServicies.Core
{
    public interface IGenericRepository<T> where T : HollywoodEntity
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Save();
    }
}
