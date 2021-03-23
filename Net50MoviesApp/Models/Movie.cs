using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Models
{
    public class Movie
    {
        
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Film başlığı eklemediniz. Eklemedir koca başlık.")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="En az 5 en fazla 50 karakter girebilirsiniz.")]
        public string Title{ get; set; }
        [Required(ErrorMessage = "Film açıklamasını eklemediniz.")]
        public string Description{ get; set; }
        [Required(ErrorMessage = "Yönetmeni eklemediniz. Hep dışlıyorsunuz.")]
        public string  Director{ get; set; }
        [Required(ErrorMessage = "Film yılını  eklemediniz. Ne zaman çıktı bu film!?")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Filmin afişi yok nasıl girecek vizyona?!")]
        public string ImageUrl { get; set; }
        public string[] Cast{ get; set; }
        [Required(ErrorMessage = "Türüne karar verdiniz mi?")]
        public int? GenreId { get; set; }
    }
}
