using Net50MoviesApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Models
{
    public class AdminMoviesViewModel
    {
        public List<AdminMovieViewModel> Movies { get; set; }
    }
    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class AdminCreateMovieViewModel
    {
        [Required(ErrorMessage ="Film adını girmelisiniz.")]
        [StringLength(50,MinimumLength =3, ErrorMessage = "Film adı 3-50 arası karakterden oluşabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Film açıklamasını eklemediniz.")]
        [StringLength(500, ErrorMessage = "Film açıklaması en fazla 500 karakterden oluşabilir.")]
        public string Description { get; set; }

        public string Year { get; set; }
        public int[] GenreIds { get; set; }
    }

    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public int[] GenreIds { get; set; }
    }
}
