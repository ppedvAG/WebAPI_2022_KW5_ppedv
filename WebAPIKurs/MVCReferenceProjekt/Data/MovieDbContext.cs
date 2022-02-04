#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerSample.SharedLib;
using Microsoft.EntityFrameworkCore;



namespace MVCReferenceProjekt.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Regisseur> Regisseure { get; set; }
    }
}
