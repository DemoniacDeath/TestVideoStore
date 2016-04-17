using NUnit.Framework;
using System.Linq;
using Example.Persistence.Tests;
using System.Data.Entity;
using Example.Persistence.Contexts;
using Example.Domain;

namespace Example.Persistence.Repositories.Tests
{
    [TestFixture]
    public class MoviesRepositoryTests
    {
        MoviesContext _context;
        MoviesRepository MoviesRepository;

        [SetUp]
        public void Init()
        {
            var initialiser = new MoviesContextTestInitializer();
            Database.SetInitializer(initialiser);

            _context = new MoviesContext();

            initialiser.InitializeDatabase(_context);
            MoviesRepository = new MoviesRepository(_context);
        }

        [TearDown]
        public void Cleanup()
        {
            Database.Delete("Movies.Test");
        }

        [Test]
        public void Get_movie_returns_correct_movie()
        {
            var Movie2 = MoviesRepository.Get(2);
            Assert.IsNotNull(Movie2);
            Assert.AreEqual(2, Movie2.MovieID);
            Assert.AreEqual("TestNewRelease", Movie2.Title);
            Assert.AreEqual(MovieType.NewRelease, Movie2.Type);
        }

        [Test]
        public void GetAll_movies_returns_all_movies()
        {
            var Movies = MoviesRepository.GetAll();
            Assert.AreEqual(3, Movies.Count());
            Assert.IsNotNull(Movies[0]);
            Assert.AreEqual(1, Movies[0].MovieID);
            Assert.AreEqual("TestRegular", Movies[0].Title);
            Assert.AreEqual(MovieType.Regular, Movies[0].Type);
            Assert.IsNotNull(Movies[1]);
            Assert.AreEqual(2, Movies[1].MovieID);
            Assert.AreEqual("TestNewRelease", Movies[1].Title);
            Assert.AreEqual(MovieType.NewRelease, Movies[1].Type);
            Assert.IsNotNull(Movies[2]);
            Assert.AreEqual(3, Movies[2].MovieID);
            Assert.AreEqual("TestForChildren", Movies[2].Title);
            Assert.AreEqual(MovieType.ForChildren, Movies[2].Type);
        }
    }
}