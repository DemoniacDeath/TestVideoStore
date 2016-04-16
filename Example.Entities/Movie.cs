using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }

        public string Title { get; set; }

        public Example.Domain.MovieType Type { get; set; }
    }
}
