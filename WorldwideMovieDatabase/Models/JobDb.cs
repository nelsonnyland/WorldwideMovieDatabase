using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public static class JobDb
    {
        public static IList<Job> GetAllJobs(ApplicationDbContext db)
        {
            return db.Jobs.ToList();
        }

        public static Job GetJob(ApplicationDbContext db, int id)
        {
            return db.Jobs.Find(id);
        }

        public static void AddJob(ApplicationDbContext db, Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
        }

        public static void UpdateJob(ApplicationDbContext db, Job job)
        {
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteJob(ApplicationDbContext db, int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
        }
    }
}