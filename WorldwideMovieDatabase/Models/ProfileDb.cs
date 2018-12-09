using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class ProfileDb
    {
        public static List<Profile> GetAllProfiles(ApplicationDbContext db)
        {
            return db.Profiles.ToList();
        }

        /// <summary>
        /// Adds a profile and movies the person worked with job titles for each movie
        /// </summary>
        /// <param name="db"></param>
        /// <param name="profile"></param>
        public static void AddProfile(ApplicationDbContext db, Profile profile)
        {
            foreach (var movie in profile.Movies)
            {
                var jobList = new List<Job>();
                foreach (var currJob in movie.Jobs)
                {
                    Job newJob = db.Jobs.Find(currJob.Id);
                    jobList.Add(newJob);
                }
                movie.Jobs = jobList;
            }
            db.Profiles.Add(profile);
            db.SaveChanges();
        }

        public static Profile FindProfile(ApplicationDbContext db, int id)
        {
            return db.Profiles.Find(id);
        }

        public static Profile GetAllProfileMovieJobs(ApplicationDbContext db, int id)
        {
            return db.Profiles
                    .Where(p => p.ID == id)
                    .Include(p => p.Movies)
                    .SingleOrDefault();
        }

        /// <summary>
        /// Updates profile information including movies and jobs titles for each movie
        /// </summary>
        /// <param name="db"></param>
        /// <param name="profile"></param>
        public static void UpdateProfile(ApplicationDbContext db, Profile profile)
        {
            foreach (var movie in profile.Movies)
            {
                movie.ProfileId = profile.ID;

                var jobList = new List<Job>();
                foreach (var currJob in movie.Jobs)
                {
                    Job newJob = db.Jobs.Find(currJob.Id);
                    jobList.Add(newJob);
                }
                movie.Jobs = jobList;
            }
            db.MovieProfiles.AddRange(profile.Movies);
            db.Entry(profile).State = EntityState.Modified;

            db.SaveChanges();
        }

        public static void RemoveProfile(ApplicationDbContext db, Profile profile)
        {
            db.Profiles.Remove(profile);
            db.SaveChanges();
        }
    }
}