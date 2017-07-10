using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id= 1, Name=  "Die Hard" };
            var customers = new List<Customer>
            {
                new Customer() { Name = "Customer 1" },
                new Customer() { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id: " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}