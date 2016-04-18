using Example.MVC.ViewModels;
using Example.Persistence.Contexts;
using Example.Persistence.Interfaces;
using Example.Persistence.Repositories;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository MoviesRepository;

        //Default behaviour - create an instance of MoviesRepository class
        //with MoviesContext to be a repositoty of movies for this controller
        public HomeController() : this(new MoviesRepository(new MoviesContext()))
        {
        }

        //Dependency injection - pass specific IRepositoty<Movie> object
        //to be a repositoty of movies for this controller
        public HomeController(IMovieRepository Repository)
        {
            MoviesRepository = Repository;
        }

        //Show default view
        public ActionResult Index()
        {
            FillTheBag();
            return View(DefaultCustomer());
        }

        //AJAX action to load a view for a new rental in the form
        //receives Count as a number of currently present rentals in the form
        public ActionResult GetNewRental(int Count)
        {
            FillTheBag();
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Rentals[{0}]", Count);
            var FakedCustomer = DefaultCustomer();
            return PartialView("EditorTemplates/Rental", FakedCustomer.Rentals[0]);
        }

        //AJAX action to generate end result - a rental bill in a form of html view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Statement(Customer Customer)
        {
            LoadMovies(Customer);
            FillTheBag();
            return PartialView("_Statement", MapDomainModel(Customer));
        }

        //File action that returns a file containing plain text form of rental bill
        public FileResult Download(Customer Customer)
        {
            LoadMovies(Customer);
            var result = new FileContentResult(Encoding.UTF8.GetBytes(MapDomainModel(Customer).GetStatement()), "text/plain");
            result.FileDownloadName = "statement.txt";
            return result;
        }

        //Loading Movie objects from repository by MovieID in a Customer object
        private void LoadMovies(Customer Customer)
        {
            foreach (var Rental in Customer.Rentals)
            {
                if (Rental.Movie != null && Rental.Movie.MovieID != 0)
                {
                    Rental.Movie = MoviesRepository.Get(Rental.Movie.MovieID);
                }
            }
        }

        private Example.Domain.Customer MapDomainModel(Customer Customer)
        {
            Example.Domain.Customer DomainCustomer = new Domain.Customer(Customer.Name);
            foreach (var Rental in Customer.Rentals)
            {
                if (Rental.Movie.Title != null && Rental.Movie.Title.Length != 0)
                {
                    Domain.Movie DomainMovie = new Domain.Movie(Rental.Movie.Title, Rental.Movie.Type);
                    Domain.Rental DomainRental = new Domain.Rental(DomainMovie, Rental.DaysRented);
                    DomainCustomer.AddRental(DomainRental);
                }
            }
            return DomainCustomer;
        }

        //Default empty Customer object for not-yet-filled view form.
        private Customer DefaultCustomer()
        {
            Customer DefaultCustomer = new Customer();
            var rental = new Rental();
            rental.DaysRented = 1;
            DefaultCustomer.Rentals.Add(rental);
            return DefaultCustomer;
        }

        //Placing lists of objects in the ViewBag to pass to js and for dropdown list generation
        private void FillTheBag()
        {
            ViewBag.MoviesList = MoviesRepository.GetAll();
            ViewBag.MovieTypesList = Enum.GetNames(typeof(Domain.MovieType)).ToList();

        }
    }
}