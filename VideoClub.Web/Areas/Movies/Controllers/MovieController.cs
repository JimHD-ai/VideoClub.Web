using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Areas.Movies.Models;

namespace VideoClub.Web.Areas.Movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieDb;
        private readonly IMovieCopyService _movieCopyDb;
        private readonly IMovieRentService _movieRentDb;

        public MovieController(IMovieService movieDb, IMovieCopyService movieCopyDb, IMovieRentService movieRentDb)
        {
            _movieDb = movieDb;
            _movieCopyDb = movieCopyDb;
            _movieRentDb = movieRentDb;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "titleDesc" : "";
            ViewBag.ReleaseDateSortParm = sortOrder == "genre" ? "genreDesc" : "genre";

            //Pagination
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var movies = _movieDb.GetMovies();

            //SearchBox
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString)
                                                      || m.Genre.ToString().Contains(searchString));
            }

            //Filtering
            switch (sortOrder)
            {
                case "titleDesc":
                    movies = movies.OrderByDescending(t => t.Title);
                    break;
                case "genre":
                    movies = movies.OrderBy(g => g.Genre);
                    break;
                case "genreDesc":
                    movies = movies.OrderByDescending(g => g.Genre);
                    break;
                default:
                    movies = movies.OrderBy(t => t.Title);
                    break;
            }

            return View(movies);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _movieDb.GetMovie(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var model = new MovieBindingModel(movie.Id, movie.Title, movie.Description, movie.Genre);
            return View(model);
        }
    }
}
