using Example.Persistence.Contexts;
using Example.Persistence.Entities;
using Example.Persistence.Interfaces;

namespace Example.Persistence.Repositories
{
    public class MoviesRepository : Repository<Movie>, IMovieRepository
    {
        public MoviesContext MoviesContext { get { return Context as MoviesContext; } }

        public MoviesRepository(MoviesContext context) : base(context)
        {
        }

        public Domain.Movie MapModel(Entities.Movie Movie)
        {
            if (Movie == null)
                return null;
            return new Domain.Movie(Movie.Title, Movie.Type);
        }
    }
}