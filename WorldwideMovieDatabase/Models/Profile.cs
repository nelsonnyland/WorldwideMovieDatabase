using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Profile
    {
        // internal identifier
        public int ID { get; set; }

        // Mel Gibson - First & Last Name
        public string Name { get; set; }

        // month/day/year of birth
        public DateTime BirthDate { get; set; }

        // month/day/year of death, null if still alive
        public DateTime DeathDate { get; set; }

        // Actor, Producer, Director
        public Movie[] Titles { get; set; }

        // "Mel Columcille Gerard Gibson..."
        public string Bio { get; set; }

        // "~/Images/..." - path for image
        public string ProfilePicture { get; set; }
    }
}