using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet]
        public IActionResult Index1()
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

        [HttpGet]
        public IActionResult Index()
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
        [HttpGet]
        public IActionResult List(int? id, string q)
        {

            //var kelime = HttpContext.Request.Query["q"].ToString();//birinci yöntem

            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var genid = RouteData.Values["id"];

            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }
            if (!String.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                //ikinci yöntem
                movies = movies.Where(t =>
                t.Title.ToLower().Contains(q) ||
                t.Description.ToLower().Contains(q)) 
                .ToList();
            }
            var model = new MovieViewModel()
            {
                Movies = movies
            };
            return View("Movies", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = MovieRepository.GetById(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie entity)
        {

            if (ModelState.IsValid)
            {
                //Movie entity //model binding
                MovieRepository.Add(entity);
                TempData["Message"] = $"{entity.Title} isimli film Eklendi.";
                return RedirectToAction("List", "Movies");
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList ( GenreRepository.Genres, "GenreId", "Name");
            var movie = MovieRepository.GetById(id);
            return View(movie) ;
        }
        [HttpPost]
        public IActionResult Edit(Movie entity)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(entity);
                TempData["Message"] = $"{entity.Title} isimli film güncellendi.";
                return RedirectToAction("Details", "Movies", new { @id = entity.MovieId });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(entity);
        }
        [HttpPost]

        public IActionResult Delete(int MovieId,string Title)
        {
            MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi.";
            return RedirectToAction("List", "Movies");
        }
    }

}
