using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModels
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            // return Content("Hello World!");
            //return HttpNotFound();
            // return RedirectToAction("Index", "Home", new { page = 1, SorBy = "Genre" });
        }

        //Get : Movies/Edit/id
        [Authorize(Roles =RoleNames.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            var movieViewModel = new NewMovieViewModel(movie)
            {
                Genres = _dbContext.Genres.ToList()
                 
            };
            if (movieViewModel == null)
            {
                return HttpNotFound();
            }
            return View("MovieForm", movieViewModel);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {

                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Movies");
        }

        //public ActionResult Index(int? pageindex, string sortby)
        //{
        //    if (!pageindex.HasValue)
        //        pageindex = 1;

        //    if (string.IsNullOrWhiteSpace(sortby))
        //        sortby = "Name";

        //    return Content(string.Format("PageIndex={0}&SortBy={1}", pageindex, sortby));
        //}

         //Get /Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }


        //GET :Movies/New
        [Authorize(Roles =RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var movieViewModel = new NewMovieViewModel()
            {
                Genres = _dbContext.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }

        [Authorize(Roles =RoleNames.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieVM = new NewMovieViewModel(movie)
                {
                    Genres = _dbContext.Genres.ToList()
                };
                return View("MovieForm", movieVM);
            }

            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var moviewDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                moviewDb.Name = movie.Name;
                moviewDb.GenreId = movie.GenreId;
                moviewDb.ReleaseDate = movie.ReleaseDate;
                moviewDb.DateAdded = movie.DateAdded;
                moviewDb.NumberInStock = movie.NumberInStock;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Route("Movies/ReleaseDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ReleaseDate(string year, string month)
        {
            return Content(string.Format("Release Date {0},{1}", year, month));
        }
    }
}