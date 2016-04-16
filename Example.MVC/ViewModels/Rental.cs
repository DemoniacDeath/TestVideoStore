using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Example.MVC.ViewModels
{
    public class Rental
    {
        public Movie Movie { get; set; }

        [Required]
        [Min(1)]
        public int DaysRented { get; set; }
    }
}