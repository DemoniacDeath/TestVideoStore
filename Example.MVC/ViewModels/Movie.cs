using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.MVC.ViewModels
{
    public class Movie
    {
        public string Title { get; set; }
        public Example.Domain.MovieType Type { get; set; }
    }
}