using Net50MoviesApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Net50MoviesApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        static MovieRepository()
        {
            _movies = new List<Movie>() {
            new Movie() {
                MovieId=1,
            Title= "Başlık1",
            Description = "Çok önemli açıklama. Çok önemli, açıklama.",
            //Director= "Sektöründe Öncü Yönetmen",
            Year= "2021",
            ImageUrl="1.jpg",
            //GenreId=1
            },
            new Movie() {
                MovieId=2,
            Title= "Başlık2",
            Description = "Yok sana açıklama falan. Çok önemli bir açıklama.",
            //Director= "İsmini Vermek İstemeyen Yönetmen",
            Year= "2005",
            ImageUrl="2.jpg",
            //GenreId=3
            },
            new Movie() {
                MovieId=3,
            Title= "Başlık3",
            Description = "Tek açıklama. Pek güzel açıklama.",
            //Director= "Alemin Hızlı Yönetmeni",
            Year= "2011",
            ImageUrl="3.jpg",
            //GenreId=4
            },
            new Movie() {
            MovieId=4,Title= "Başlık4",
            Description = "Çok iyi açıklama. Çok önemliyse açıklama.",
            //Director= "Gizli Yönetmen",
            Year= "2014",
            ImageUrl="4.jpg"
            //,GenreId=1
            },
            new Movie() {
                MovieId=5,
            Title= "Başlık5",
            Description = "Çok güzel açıklama. Çok açıklama.",
            //Director= "Çakma Yönetmen",
            Year= "2008",
            ImageUrl="5.jpg",
            //GenreId=2
            }};
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }
        public static Movie GetById(int Id)
        {
            Movie result = _movies.FirstOrDefault(k => k.MovieId == Id);
            return result;
        }
        public static void Edit(Movie movie)
        {
            var mov = GetById(movie.MovieId);
            mov.Title = movie.Title;
            mov.Description = movie.Description;
            //mov.Director = movie.Director;
            mov.ImageUrl = movie.ImageUrl;
            mov.Year = movie.Year;
            //mov.GenreId = movie.GenreId;
        }

        public static void Delete(int MovieId)
        {
            var mov = GetById(MovieId);
            if (mov != null)
            {
                _movies.Remove(mov);
            }
        }
    }
}
