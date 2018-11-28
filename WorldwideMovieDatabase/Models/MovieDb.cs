using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class MovieDb
    {
        public static void AddMovies(ICollection<Movie> movies)
        {
            var db = new ApplicationDbContext();
            db.Movies.AddRange(movies);
            db.SaveChanges();
        }
    }
}