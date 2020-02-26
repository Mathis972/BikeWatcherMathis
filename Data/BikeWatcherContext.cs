using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeWatcher.Data
{
    public class BikeWatcherContext : DbContext
    {
        public BikeWatcherContext(DbContextOptions<BikeWatcherContext> options) : base(options)
        {
        }

        public DbSet<Favoris> Favoris { get; set; }
        public DbSet<BrokenBike> BrokenBike { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favoris>().ToTable("Favori");
        
            modelBuilder.Entity<BrokenBike>().ToTable("BrokenBikes");
        }
    }
}
