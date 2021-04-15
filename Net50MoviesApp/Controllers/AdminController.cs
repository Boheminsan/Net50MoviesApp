using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net50MoviesApp.Data;
using Net50MoviesApp.Entity;
using Net50MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Net50MoviesApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext context;

        public AdminController(MovieContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Movie
        public IActionResult MovieList()
        {
            var model = new AdminMoviesViewModel
            {
                Movies = context.Movies
                .Include(m => m.Genres)
                .Select(m => new AdminMovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Year = m.Year,
                    ImageUrl = m.ImageUrl,
                    Genres = m.Genres.ToList()
                })
                .ToList()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult MovieCreate()
        {
            ViewBag.Genres = context.Genres.ToList();
            return View(new AdminCreateMovieViewModel());
        }

        [HttpPost]
        public IActionResult MovieCreate(AdminCreateMovieViewModel m)
        {
            if (m.Title!=null && m.Title.Contains("@"))
            {
                ModelState.AddModelError("", "Film başlığı @ işareti içeremez.");
            }
            
                if (m.GenreIds==null)
            {
                ModelState.AddModelError("GenreIds", "Tür seçmediniz.");
            }
            if (ModelState.IsValid)
            {
                var entity = new Movie()
                {
                    Title=m.Title,
                    Description=m.Description
                };
                
                foreach (var id in m.GenreIds)
                {
                    entity.Genres.Add(context.Genres.FirstOrDefault(i=>i.GenreId==id));
                }

                context.Movies.Add(entity);
                context.SaveChanges();
                return RedirectToAction("MovieList","Admin");
            }
            ViewBag.Genres = context.Genres.ToList();
            return RedirectToAction("MovieCreate");
        }

        [HttpGet]
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var entity = context.Movies.Select(m => new AdminEditMovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Year = m.Year,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                    GenreIds = m.Genres.Select(i=>i.GenreId).ToArray()
                }).FirstOrDefault(m => m.MovieId == id);
                ViewBag.Genres = context.Genres.ToList();
                if (entity == null)
                {
                    return NotFound();
                }
                return View(entity);
            }
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> MovieUpdateAsync(AdminEditMovieViewModel model, int[] genreId, IFormFile file)
        {
            if (ModelState.IsValid)
            {
            var entity = context.Movies.Include(m => m.Genres).FirstOrDefault(m => m.MovieId == model.MovieId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = model.Title;
            entity.Year = model.Year;
            entity.Description = model.Description;

            if (file != null)
            {

                var extension = Path.GetExtension(file.FileName);
                var filename = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", filename);
                
                entity.ImageUrl = filename;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            entity.Genres = genreId.Select(g => context.Genres.FirstOrDefault(i => i.GenreId == g)).ToList();

            context.SaveChanges();
            return RedirectToAction("MovieList");
            }
            ViewBag.Genres = context.Genres.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult MovieDelete(int movieId)
        {
            var entity = context.Movies.Find(movieId);
            if (entity != null)
            {
                context.Movies.Remove(entity);
                context.SaveChanges();
            }
            return RedirectToAction("MovieList");
        }


        //Genre
        public IActionResult GenreList()
        {
            var model = new AdminGenresViewModel
            {
                Genres = context.Genres
                .Select(g => new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                })
                .ToList()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var entity = context.Genres.Select(g => new AdminEditGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(i => new AdminMovieViewModel
                    {
                        MovieId = i.MovieId,
                        ImageUrl = i.ImageUrl,
                        Title = i.Title,
                        Year = i.Year
                    }).ToList()
                }).FirstOrDefault(m => m.GenreId == id);
                if (entity == null)
                {
                    return NotFound();
                }
                return View(entity);
            }
        }
        [HttpPost]
        public IActionResult GenreUpdate(AdminEditGenreViewModel model, int[] movieId)
        {
            var entity = context.Genres.Include("Movies").FirstOrDefault(m => m.GenreId == model.GenreId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            if (movieId.Any())
            {
                foreach (var id in movieId)
                {
                    entity.Movies.Remove(entity.Movies.FirstOrDefault(i => i.MovieId == id));
                }
            }
            context.SaveChanges();
            return RedirectToAction("GenreList");
        }
        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var entity = context.Genres.Find(genreId);
            if (entity != null)
            {
                context.Genres.Remove(entity);
                context.SaveChanges();
            }
            return RedirectToAction("GenreList");
        }
    }
}
