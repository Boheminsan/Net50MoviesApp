using Net50MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Director= "Sektöründe Öncü Yönetmen",
            Cast= new string[] { "Oyuncu1", "Oyuncu5", "Oyuncu2", "Oyuncu4" },
            Year= "2021",
            ImageUrl="1.jpg"
            },
            new Movie() {
                MovieId=2,
            Title= "Başlık2",
            Description = "Yok sana açıklama falan. Çok önemli bir açıklama.",
            Director= "İsmini Vermek İstemeyen Yönetmen",
            Cast= new string[]{ "Oyuncu10", "Oyuncu2", "Oyuncu7", "Oyuncu3" },
            Year= "2005",
            ImageUrl="2.jpg"
            },
            new Movie() {
                MovieId=3,
            Title= "Başlık3",
            Description = "Tek açıklama. Pek güzel açıklama.",
            Director= "Alemin Hızlı Yönetmeni",
            Cast= new string[]{ "Oyuncu3", "Oyuncu5", "Oyuncu4", "Oyuncu7" },
            Year= "2011",
            ImageUrl="3.jpg"
            },
            new Movie() {
            MovieId=4,Title= "Başlık4",
            Description = "Çok iyi açıklama. Çok önemliyse açıklama.",
            Director= "Gizli Yönetmen",
            Cast= new string[]{ "Oyuncu1", "Oyuncu3", "Oyuncu8", "Oyuncu5" },
            Year= "2014",
            ImageUrl="4.jpg"
            },
            new Movie() {
                MovieId=5,
            Title= "Başlık5",
            Description = "Çok güzel açıklama. Çok açıklama.",
            Director= "Çakma Yönetmen",
            Cast= new string[]{ "Oyuncu7", "Oyuncu2", "Oyuncu10", "Oyuncu9" },
            Year= "2008",
            ImageUrl="5.jpg"
            }};
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }
        public static Movie GetById(int Id)
        {
            Movie result = _movies.FirstOrDefault(k => k.MovieId == Id);
            return result;
        }
    }
}
