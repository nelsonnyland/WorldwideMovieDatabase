using System;
using System.Collections.Generic;
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


        public static ICollection<Movie> GetProfileMovies(int? id)
        {

            //https://stackoverflow.com/questions/2767709/join-where-with-linq-and-lambda
            //https://stackoverflow.com/questions/9720225/how-to-perform-join-between-multiple-tables-in-linq-lambda
            var db = new ApplicationDbContext();
            return db
                .Profiles
                .Join(db.MovieProfiles,
                    p => p.ID,
                    mp => mp.ProfileId,
                    (p, mp) => new { p.ID, mp.MovieId })
                .Join(db.Movies,
                    mp => mp.MovieId,
                    m => m.ID,
                    (mp, m) => new { mp, m.Title })
                .Where(p => p.ID == id)
                .ToList();
        }
    }
}