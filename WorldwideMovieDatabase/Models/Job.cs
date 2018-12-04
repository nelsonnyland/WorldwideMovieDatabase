using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Job
    {
        public Job()
        {
            MovieProfiles = new List<MovieProfile>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IList<MovieProfile> MovieProfiles { get; set; }
    }
}