using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyDatabase.Initializers;

namespace MyDatabase
{
    internal class ApplcationDbContext : DbContext
    {
        public ApplcationDbContext() : base("Sindesmos")
        {
            Database.SetInitializer<ApplcationDbContext>(new MockupDbInitializer());
            Database.Initialize(false);

                
        }
    }
}
