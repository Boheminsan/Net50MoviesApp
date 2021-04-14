using Microsoft.AspNetCore.Mvc;
using Net50MoviesApp.Data;
using System.Linq;

namespace Net50MoviesApp.ViewComponents
{

    public class GenresViewComponent : ViewComponent
    {
        private readonly MovieContext context;

        public GenresViewComponent(MovieContext _context)
        {
            context = _context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData.Values["id"];
            return View(context.Genres.ToList());
        }
    }
}
