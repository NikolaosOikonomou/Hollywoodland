using Entities.Models;
using ReposotoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryServicies.Core
{
    public interface IUnitOfWork : IDisposable
    { 
        IGenericRepository<Movie> Movies { get; }

        int Complete();
    }
}
