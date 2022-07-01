using Entities.Models;
using RepositoryServicies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServicies.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }

        IActorRepository Actors { get; }

        int Complete();
    }
}
