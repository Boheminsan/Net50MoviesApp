
using System.Collections.Generic;

namespace Net50MoviesApp.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
