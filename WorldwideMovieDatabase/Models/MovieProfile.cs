using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class MovieProfile
    {
        public MovieProfile()
        {
            Jobs = new List<Job>();
        }

        [Key]
        public int MovieProfileId { get; set; }

        public int MovieId { get; set; }

        public int ProfileId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual IList<Job> Jobs { get; set; }
    }
}