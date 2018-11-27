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


        public static List<Movie> GetProfileMovies(int? id)
        {

            //https://stackoverflow.com/questions/2767709/join-where-with-linq-and-lambda
            //https://stackoverflow.com/questions/9720225/how-to-perform-join-between-multiple-tables-in-linq-lambda
            var db = new ApplicationDbContext();
            var query = db.Profiles
                            .Where(p => p.ID == id)
                            .Join(db.MovieProfiles,
                                p => p.ID,
                                mp => mp.ProfileId,
                                (p, mp) => new { p, mp })
                            .Join(db.Movies,
                                pmp => pmp.mp.MovieId,
                                m => m.ID,
                                (pmp, m) => new { m.Title });

            List<Movie> movieList = new List<Movie>();
            foreach (var item in query)
            {
                movieList.Add(new Movie { Title = item.Title });
            }
            return movieList;
        }
    }
}