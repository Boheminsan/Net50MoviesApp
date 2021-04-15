using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Net50MoviesApp.Entity
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
        }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
 
        //public string Director { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        //public string[] Cast { get; set; }
        public List<Genre> Genres { get; set; }
        //public int? GenreId { get; set; }

    }
}
