using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Example.Entities;

namespace Example.MVC.Models
{
    public class MoviesRepository
    {
        protected readonly MoviesContext Context;

        public MoviesRepository()
        {
            Context = new MoviesContext();
        }

        public Domain.Movie Get(int id)
        {
            Movie MovieEF = Context.Movies.Find(id);
            if (MovieEF == null)
                return null;
            return MapModel(MovieEF);
        }

        public IEnumerable<Domain.Movie> GetAll()
        {
            return from MovieEF in Context.Movies.ToList()
            select MapModel(MovieEF);
        }

        protected Domain.Movie MapModel(Entities.Movie MovieEF)
        {
            if (MovieEF == null)
                return null;
            return new Domain.Movie(MovieEF.Title, MovieEF.Type);
        }

    }
}