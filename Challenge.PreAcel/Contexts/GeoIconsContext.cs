
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Challenge.PreAcel.Entities;

namespace Challenge.PreAcel.Contexts
{
    public class GeoIconsContext : DbContext
    {

        public GeoIconsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Continent> Continents { get; set; } = null!;
        public DbSet<City> City { get; set; } = null!;
        public DbSet<GeograpihcIcon> GeograpihcIcons { get; set; } = null!;

    }


}