using Net50MoviesApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Models
{
    public class AdminGenresViewModel
    {
        public List<AdminGenreViewModel> Genres { get; set; }

    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

    }

    public class AdminEditGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<AdminMovieViewModel> Movies{ get; set; }

    }
}
