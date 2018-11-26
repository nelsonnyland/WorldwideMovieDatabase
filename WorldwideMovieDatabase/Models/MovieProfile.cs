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
        [Key]
        public int MovieProfileId { get; set; }
        //[Key]
        //[Column(Order = 0)]
        public int MovieId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public int ProfileId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Profile Profile { get; set; }

        public string JobTitle { get; set; }
    }
}