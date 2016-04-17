using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using Example.Persistence.Entities;

namespace Example.MVC.ViewModels
{
    public class Rental
    {
        public virtual Movie Movie { get; set; }

        [Required]
        [Min(1)]
        public int DaysRented { get; set; }
    }
}