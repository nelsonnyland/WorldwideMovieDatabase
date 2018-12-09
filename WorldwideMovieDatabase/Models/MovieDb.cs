using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class MovieDb
    {
        public static void AddMovies(ApplicationDbContext db, ICollection<Movie> movies)
        {
            db.Movies.AddRange(movies);
            db.SaveChanges();
        }

        public static IList<Movie> GetAllMovies(ApplicationDbContext db)
        {
            return db.Movies.ToList();
        }

        /// <summary>
        /// Gets Movie by id
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Movie GetMovie(ApplicationDbContext db, int id)
        {
            return db.Movies.Find(id);
        }

        public static void UpdateMovie(ApplicationDbContext db, Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteMovie(ApplicationDbContext db, Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
        }
    }
}