using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class JobTitle
    {
        public JobTitle()
        {
            Profiles = new HashSet<Profile>();
        }
        
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The actual name of the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The people the title belongs to
        /// </summary>
        public ICollection<Profile> Profiles { get; set; }
    }
}