using NUnit.Framework;
using Moq;
using Example.Persistence.Interfaces;
using System.Web.Mvc;
using Example.Persistence.Entities;
using System.Collections.Generic;

namespace Example.MVC.Controllers.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        HomeController HomeController;

        [SetUp]
        public void Init()
        {
            var data = new List<Movie>();
            data.Add(new Movie { Title = "test", Type = Domain.MovieType.Regular });
            data.Add(new Movie { Title = "test2", Type = Domain.MovieType.NewRelease });
            data.Add(new Movie { Title = "test3", Type = Domain.MovieType.ForChildren });
            var MockRepository = new Mock<IMovieRepository>();
            MockRepository.Setup(obj => obj.GetAll()).Returns(data);
            MockRepository.Setup(obj => obj.Get(It.IsAny<int>())).Returns((int id)=>data[id]);
            HomeController = new HomeController(MockRepository.Object);
        }

        [Test]
        public void Index_action_test()
        {
            var result = HomeController.Index() as ViewResult;
            Assert.That(result, Is.Not.Null);
        }
    }
}