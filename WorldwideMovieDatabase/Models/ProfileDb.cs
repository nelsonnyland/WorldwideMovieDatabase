using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static Profile FindProfile(int? id)
        {
            return new ApplicationDbContext().Profiles.Find(id);
        }

        public static Profile GetAllProfileMovieJobs(int? id)
        {
            var db = new ApplicationDbContext();
            return db.Profiles
                    .Where(p => p.ID == id)
                    .Include(p => p.Movies)
                    .SingleOrDefault();
        }
    }
}