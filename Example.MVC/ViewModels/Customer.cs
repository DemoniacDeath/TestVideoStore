using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example.MVC.ViewModels
{
    public class Customer
    {
        [Required]
        public string Name { get; set; }

        public IList<Rental> Rentals { get; private set; }

        public Customer()
        {
            Rentals = new List<Rental>();
        }

        public Example.Domain.Customer MapDomainModel()
        {
            Example.Domain.Customer DomainCustomer = new Example.Domain.Customer(Name);
            foreach (var Rental in Rentals)
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

        public string GetHtmlStatement()
        {
            Domain.Customer DomainCustomer = MapDomainModel();
            HtmlStatementBuilder builder = new HtmlStatementBuilder();
            return DomainCustomer.GetStatement(builder);
        }

        public string GetTextStatement()
        {
            Domain.Customer DomainCustomer = MapDomainModel();
            return DomainCustomer.GetStatement();
        }
    }
}