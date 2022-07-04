using Entities.Models;
using MyDatabase;
using RepositoryServicies.Core;
using RepositoryServicies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UnitOfWork unit = new UnitOfWork(db); 
            
            
            
        }
    }
}
