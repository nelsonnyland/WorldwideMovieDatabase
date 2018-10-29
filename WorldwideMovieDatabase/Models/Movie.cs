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
        public string Title { get; set; }

        // 1995 - Release Year
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        // 8.4 - 861,254 users
        [Display(Name = "User Rating")]
        public double UserRating { get; set; }

        // R - Mature Audiences
        [Display(Name = "MPAA Rating")]
        public string MPAARating { get; set; }

        // 2h 58min - movie runtime
        [Display(Name = "Movie Length")]
        public string MovieLength { get; set; }

        // Drama - genre
        public string Genre { get; set; }

        // "When his secret bride is executed..."
        public string Description { get; set; }

        // Mel Gibson, Sophie Marceau...
        public List<Profile> Actors { get; set; }
    }
}