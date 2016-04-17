using Example.Persistence.Contexts;
using Example.Domain;
using System.Data.Entity;

namespace Example.Persistence.Tests
{
    public class MoviesContextTestInitializer : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext Context)
        {
            Context.Movies.Add(new Entities.Movie() { Title = "TestRegular", Type = MovieType.Regular });
            Context.Movies.Add(new Entities.Movie() { Title = "TestNewRelease", Type = Domain.MovieType.NewRelease });
            Context.Movies.Add(new Entities.Movie() { Title = "TestForChildren", Type = Domain.MovieType.ForChildren });
            Context.SaveChanges();
        }

    }
}
