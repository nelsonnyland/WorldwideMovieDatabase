using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class MovieProfileDb
    {
        public static void AddMovieProfiles(ApplicationDbContext db,ICollection<MovieProfile> movieProfiles)
        {
            db.MovieProfiles.AddRange(movieProfiles);
            db.SaveChanges();
        }
    }
}