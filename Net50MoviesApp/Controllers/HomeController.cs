using Microsoft.AspNetCore.Mvc;
using Net50MoviesApp.Data;
using Net50MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularMovies = MovieRepository.Movies
            };
            return View(model);
        }
        public IActionResult About()
        {
            var turLis = new List<Genre>()
            {
                new Genre(){Name="Romantik"},
                new Genre(){Name="Macera"},
                new Genre(){Name="Komedi"},
                new Genre(){Name="Aksiyon"},
                new Genre(){Name="Dram"},
                new Genre(){Name="Polisiye"}
            };
            return View(turLis);
        }
    }
}
