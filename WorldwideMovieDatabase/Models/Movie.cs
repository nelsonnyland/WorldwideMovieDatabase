using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Movie
    {
        // internal identifier
        [Key]
        public int ID { get; set; }
        
        // Braveheart - Title
        //Instead of a comment example you could put a documentation comment. Then it pops
        //up in Intellisense
        /// <summary>
        /// Title of the Movie. Ex. Braveheart
        /// </summary>
        public string Title { get; set; }

        // 1995 - Release Year
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        //since UserRating is a double you can only store one value like 8.4, the comment is a little misleading
        //You could say AverageUserRating
        // 8.4 - 861,254 users
        [Display(Name = "User Rating")]
        public double UserRating { get; set; }

        // R - Mature Audiences
        [Display(Name = "MPAA Rating")]
        public string MPAARating { get; set; }

        // 2h 58min - movie runtime
        [Display(Name = "Movie Length")]
        public TimeSpan MovieLength { get; set; }

        // Drama - genre
        public string Genre { get; set; }

        // "When his secret bride is executed..."
        public string Description { get; set; }

        // Mel Gibson, Sophie Marceau...
        public List<Profile> Actors { get; set; }
    }
}