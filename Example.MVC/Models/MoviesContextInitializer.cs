using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Example.MVC.Models
{
    public class MoviesContextInitializer : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext Context)
        {
            Context.Movies.Add(new Entities.Movie() { Title = "The Others", Type = Domain.MovieType.Regular });
            Context.Movies.Add(new Entities.Movie() { Title = "Batman v Superman: Dawn of Justice", Type = Domain.MovieType.NewRelease });
            Context.Movies.Add(new Entities.Movie() { Title = "Inside Out", Type = Domain.MovieType.ForChildren });
            Context.Movies.Add(new Entities.Movie() { Title = "Star Wars: The Force Awakens", Type = Domain.MovieType.Regular });
            Context.Movies.Add(new Entities.Movie() { Title = "Captain America: Civil War", Type = Domain.MovieType.NewRelease });
            Context.SaveChanges();
        }

    }
}