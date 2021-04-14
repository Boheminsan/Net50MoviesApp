using Microsoft.AspNetCore.Mvc;
using Net50MoviesApp.Data;
using Net50MoviesApp.Entity;
using Net50MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Net50MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext context;

        public HomeController(MovieContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularMovies = context.Movies.ToList()
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
