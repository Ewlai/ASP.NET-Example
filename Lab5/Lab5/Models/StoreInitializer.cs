using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab5.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var pop = new Genre();
            pop.Name = "Pop";
            context.Genres.Add(pop);
            context.SaveChanges();

            var rock = new Genre();
            rock.Name = "Rock";
            context.Genres.Add(rock);
            context.SaveChanges();

            var country = new Genre();
            country.Name = "Country";
            context.Genres.Add(country);
            context.SaveChanges();

            var classical = new Genre();
            classical.Name = "Classical";
            context.Genres.Add(classical);
            context.SaveChanges();

            var hiphop = new Genre();
            hiphop.Name = "Hip-Hop";
            context.Genres.Add(hiphop);
            context.SaveChanges();

            var dance = new Genre();
            dance.Name = "Dance";
            context.Genres.Add(dance);
            context.SaveChanges();

            var electronic = new Genre();
            electronic.Name = "Electronic";
            context.Genres.Add(electronic);
            context.SaveChanges();

            var indie = new Genre();
            indie.Name = "Indie";
            context.Genres.Add(indie);
            context.SaveChanges();

        }

    }
}