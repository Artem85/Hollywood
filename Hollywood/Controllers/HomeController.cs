using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hollywood.Models;
using Hollywood.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hollywood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ActorDbContext _context;

        public HomeController(ActorDbContext context)
        {
            _context = context;
        }

        // GET: HomeController
        [Route("Home/Index")]
        public ActionResult Index(int? movieId)
        {
            List<MovieModel> movieModels = _context.Movies
                .Select(m => new MovieModel { Id = m.Id, Name = m.Title })
                .ToList();

            movieModels.Insert(0, new MovieModel { Id = 0, Name = "All" });

            IndexViewModel ivm = new IndexViewModel { Actors = _context.Actors.ToList(), Movies = movieModels };

            if (movieId != null && movieId > 0)
            {
                ivm.Actors = _context.Actors //.Include(a => a.ActorMovies)
                    .Where(a => a.ActorMovies.Any(am => am.MovieId == movieId));
            }

            return View(ivm);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
