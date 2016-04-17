using NUnit.Framework;
using Moq;
using Example.Persistence.Interfaces;

namespace Example.MVC.Controllers.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        HomeController HomeController;

        [SetUp]
        public void Init()
        {
            var MockRepository = new Mock<IMovieRepository>();
            HomeController = new HomeController();
        }

        [Test]
        public void Index_action_test()
        {
            var result = HomeController.Index();
            Assert.IsNotNull(result);
        }
    }
}