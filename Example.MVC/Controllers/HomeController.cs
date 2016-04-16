using Example.MVC.Models;
using Example.MVC.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MoviesList = GetMoviesList();
            return View(DefaultCustomer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer customer)
        {
            ViewBag.MoviesList = GetMoviesList();
            ViewBag.MovieTypesList = Enum.GetNames(typeof(Example.Domain.MovieType));
            if (ModelState.IsValid)
            {
                ViewBag.DisplayStatement = true;
            }
            return View(customer);
        }

        public ActionResult GetNewRental(int Count)
        {
            ViewBag.MoviesList = GetMoviesList();
            var FakedCustomer = DefaultCustomer();
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Rentals[{0}]", Count);
            return PartialView("~/Views/Shared/EditorTemplates/Rental.cshtml", FakedCustomer.Rentals[0]);
        }

        protected IEnumerable<Domain.Movie> GetMoviesList()
        {
            MoviesRepository repository = new MoviesRepository();
            return repository.GetAll();
        }

        private Customer DefaultCustomer()
        {
            Customer DefaultCustomer = new Customer();
            var rental = new Rental();
            rental.DaysRented = 1;
            DefaultCustomer.Rentals.Add(rental);
            return DefaultCustomer;
        }
    }
}