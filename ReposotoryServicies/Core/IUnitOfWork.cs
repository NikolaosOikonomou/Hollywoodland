using Entities.Models;
using ReposotoryServicies.Core.Repositories;
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
        IMovieRepository Movies { get; }

        IActorRepository Actors { get; }

        int Complete();
    }
}
