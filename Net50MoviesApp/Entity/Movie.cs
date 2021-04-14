using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Net50MoviesApp.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Film başlığı eklemediniz. Eklemedir koca başlık.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "En az 5 en fazla 50 karakter girebilirsiniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Film açıklamasını eklemediniz.")]
        [MaxLength(500)]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Yönetmeni eklemediniz. Hep dışlıyorsunuz.")]
        //public string Director { get; set; }
        [Required(ErrorMessage = "Film yılını  eklemediniz. Ne zaman çıktı bu film!?")]
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        //public string[] Cast { get; set; }

        public List<Genre> Genres { get; set; }
        //public int? GenreId { get; set; }

    }
}
