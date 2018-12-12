using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Movie
    {
        public Movie()
        {
            Actors = new List<MovieProfile>();
        }

        // internal identifier
        [Key]
        public int ID { get; set; }
        
        // Braveheart - Title
        public string Title { get; set; }

        // 1995 - Release Year
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        // 8.4 - 861,254 users
        [Display(Name = "User Rating")]
        public double? UserRating { get; set; }

        // R - Mature Audiences
        [Display(Name = "MPAA Rating")]
        public string MPAARating { get; set; }

        // 2h 58min - movie runtime
        [Display(Name = "Movie Length")]
        public TimeSpan? MovieLength { get; set; }

        // Drama - genre
        public string Genre { get; set; }

        // "When his secret bride is executed..."
        public string Description { get; set; }

        // Mel Gibson, Sophie Marceau...
        public virtual IList<MovieProfile> Actors { get; set; }

        // "/Images/..." - path for image
        [Display(Name = "Movie Poster URL: \"/Images/Braveheart.jpg\"")]
        public string MoviePoster { get; set; }
    }
}