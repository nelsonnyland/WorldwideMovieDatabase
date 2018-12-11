using System;
using System.Collections.Generic;
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
    }
}