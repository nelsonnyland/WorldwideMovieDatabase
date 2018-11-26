using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class MovieProfileDb
    {
        public static void AddMovieProfiles(ICollection<MovieProfile> movieProfiles)
        {
            var db = new ApplicationDbContext();
            db.MovieProfiles.AddRange(movieProfiles);
            db.SaveChanges();
        }
    }
}