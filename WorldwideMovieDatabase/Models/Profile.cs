using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Profile
    {
        public Profile()
        {
            Movies = new List<MovieProfile>();
        }

        // internal identifier
        [Key]
        public int ID { get; set; }

        // Mel Gibson - First & Last Name
        public string Name { get; set; }

        // movies they worked in
        public virtual IList<MovieProfile> Movies { get; set; }

        // month/day/year of birth
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        // month/day/year of death, null if still alive
        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        public DateTime? DeathDate { get; set; }

        // "Mel Columcille Gerard Gibson..."
        public string Bio { get; set; }

        // "~/Images/..." - path for image
        [Display(Name = "Profile Picture URL")]
        public string ProfilePicture { get; set; }
    }

    public class ProfileMoviesJobsViewModel
    {
        public ProfileMoviesJobsViewModel()
        {
            AllJobs = new List<Job>();
            AllMovies = new List<Movie>();
            MoviesToAdd = new List<MovieProfile>();
        }
        
        public Profile Profile { get; set; }

        // All jobs from Jobs table
        public IList<Job> AllJobs { get; set; }

        // All movies from Movies table
        public IList<Movie> AllMovies { get; set; }

        // Movies to add to profile
        public IList<MovieProfile> MoviesToAdd { get; set; }
    }
}