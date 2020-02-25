using BikeWatcher.Models;
using BikeWatcher.Data;
using System;
using System.Linq;

namespace BikeWatcher.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BikeWatcherContext context)
        {
            context.Database.EnsureCreated();

            if (context.Favoris.Any())
            {
                return;   // DB has been seeded
            }

            var favorites = new Favoris[]
            {
            new Favoris{IDBikeStation=16005},
            new Favoris{IDBikeStation=16045}

            };
            foreach (Favoris f in favorites)
            {
                context.Favoris.Add(f);
            }
            context.SaveChanges();

        }
    }
}
