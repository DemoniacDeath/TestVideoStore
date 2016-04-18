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
    }
}