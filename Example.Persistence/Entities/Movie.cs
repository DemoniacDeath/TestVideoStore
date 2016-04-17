namespace Example.Persistence.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }

        public string Title { get; set; }

        public Example.Domain.MovieType Type { get; set; }
    }
}
