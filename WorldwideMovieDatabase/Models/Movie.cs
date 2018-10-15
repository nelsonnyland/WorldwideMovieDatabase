using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldwideMovieDatabase.Models
{
    public class Movie
    {
        // internal identifier
        public int ID { get; set; }
        
        // Braveheart - Title
        public string Title { get; set; }

        // 1995 - Release Year
        public DateTime ReleaseYear { get; set; }

        // 8.4 - 861,254 users
        public double UserRating { get; set; }

        // R - Mature Audiences
        public string MPAARating { get; set; }

        // 2h 58min - movie runtime
        public TimeSpan MovieLength { get; set; }

        // Drama - genre
        public string Genre { get; set; }

        // "When his secret bride is executed..."
        public string Description { get; set; }

        // Mel Gibson - Director
        public string Director { get; set; }

        // Mel Gibson, Sophie Marceau...
        public List<Profile> Actors { get; set; }
    }
}