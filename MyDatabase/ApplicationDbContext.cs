using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyDatabase.Initializers;
using Entities.Models;

namespace MyDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Sindesmos")
        {
            Database.SetInitializer<ApplicationDbContext>(new MockupDbInitializer());
            Database.Initialize(false);  
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
