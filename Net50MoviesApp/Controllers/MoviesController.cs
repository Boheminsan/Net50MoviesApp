using Microsoft.AspNetCore.Mvc;
using Net50MoviesApp.Data;
using Net50MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            string filmBaslik = "Başlık1";
            string filmAciklama = "Çok önemli açıklama. Çok önemli, açıklama.";
            string filmYonetmen = "Sektöründe Öncü Yönetmen";
            string[] oyuncular = { "Oyuncu1", "Oyuncu2", "Oyuncu3", "Oyuncu4" };
            string cikisYili = "2021";

            ViewBag.FilmBaslik = filmBaslik;
            ViewBag.FilmAciklama = filmAciklama;
            ViewBag.FilmYonetmen = filmYonetmen;
            ViewBag.Oyuncular = oyuncular;
            ViewBag.CikisYili = cikisYili;

            return View();
        }

        public IActionResult Index1()
        {
            ViewBag.Title = "Movies";
            string filmBaslik = "Başlık1";
            string filmAciklama = "Çok önemli açıklama. Çok önemli, açıklama.";
            string filmYonetmen = "Sektöründe Öncü Yönetmen";
            string[] oyuncular = { "Oyuncu1", "Oyuncu2", "Oyuncu3", "Oyuncu4" };
            string cikisYili = "2021";

            var m = new Movie()
            {
                Title = filmBaslik,
                Description = filmAciklama,
                Director = filmYonetmen,
                Cast = oyuncular,
                Year = cikisYili
            };

            return View(m);
        }
        public IActionResult List()
        {
            var model = new MovieViewModel() { 
            Movies=MovieRepository.Movies
            };
            return View("Movies",model);
        }
        public IActionResult Details()
        {
            return View();
        }
    }

}
