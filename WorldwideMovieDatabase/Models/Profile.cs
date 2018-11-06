using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Profile
    {
        // internal identifier
        [Key]
        public int ID { get; set; }

        // Mel Gibson - First & Last Name
        public string Name { get; set; }

        // movies they worked in
        public List<Movie> Movies { get; set; }

        // month/day/year of birth
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        // month/day/year of death, null if still alive
        //I would replace all these single line comments with documentation comments
        //If you want DeathDate to be optional, make sure you use a nullable type. DateTime?
        //Otherwise, since datetime is a structure is always has a value, nulls are not allowed
        [Display(Name = "Date of Death")]
        public DateTime DeathDate { get; set; }

        // Actor, Producer, Director
        public List<string> Titles { get; set; }

        // "Mel Columcille Gerard Gibson..."
        public string Bio { get; set; }

        // "~/Images/..." - path for image
        [Display(Name = "Profile Picture URL")]
        public string ProfilePicture { get; set; }
    }
}