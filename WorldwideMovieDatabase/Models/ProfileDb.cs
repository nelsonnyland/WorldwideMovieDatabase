using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class ProfileDb
    {
        public static void AddProfile(Profile currProfile)
        {
            var db = new ApplicationDbContext();
            db.Profiles.Add(currProfile);
            db.SaveChanges();
        }
    }
}