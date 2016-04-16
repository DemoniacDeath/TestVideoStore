namespace Example.Domain
{
    public class Movie
    {
        public string Title { get; private set; }

        public MovieType Type { get; private set; }

        public Movie(string title, MovieType type)
        {
            Title = title;
            Type = type;
        }
    }
}
