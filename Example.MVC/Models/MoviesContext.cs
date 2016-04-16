using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Example.MVC.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Example.Entities.Movie> Movies { get; set; }
    }
}