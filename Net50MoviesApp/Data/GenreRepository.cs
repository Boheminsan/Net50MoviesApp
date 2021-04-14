using Net50MoviesApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Net50MoviesApp.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;
        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre(){GenreId=1,Name="Romantik"},
                new Genre(){GenreId=2,Name="Macera"},
                new Genre(){GenreId=3,Name="Komedi"},
                new Genre(){GenreId=4,Name="Aksiyon"},
                new Genre(){GenreId=5,Name="Dram"},
                new Genre(){GenreId=6,Name="Polisiye"}
            };
        }
        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }
        public void Add(Genre genre)
        {
            _genres.Add(genre);
        }
        public static Genre GetById(int Id)
        {
            Genre result = _genres.FirstOrDefault(k => k.GenreId == Id);
            return result;
        }
    }
}
