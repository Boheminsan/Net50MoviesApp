using Microsoft.AspNetCore.Mvc;
using Net50MoviesApp.Data;
using Net50MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View(GenreRepository.Genres);
        }
    }
}
