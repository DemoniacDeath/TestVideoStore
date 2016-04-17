using System.Data.Entity;

namespace Example.Persistence.Contexts
{
    public class MoviesContext : DbContext
    {
        public DbSet<Entities.Movie> Movies { get; set; }
    }
}