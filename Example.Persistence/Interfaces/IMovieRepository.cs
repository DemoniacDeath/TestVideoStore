using Example.Persistence.Entities;

namespace Example.Persistence.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Domain.Movie MapModel(Entities.Movie Movie);
    }
}
