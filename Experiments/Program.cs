using Entities.Models;
using MyDatabase;
using ReposotoryServicies.Core;
using ReposotoryServicies.Persistance;
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
            IGenericRepository<Actor> repo = new GenericRepository<Actor>(db);

            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.FirstName);
            } 
        }
    }
}
