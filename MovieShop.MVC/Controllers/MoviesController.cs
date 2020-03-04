using MovieShop.Services;
using System.Linq;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService =movieService;
            _genreService = genreService;
        }
        // GET: Movies
        [HttpGet]
        public ActionResult TopMovies()
        {
            var topMovies = _movieService.GetTopRenevueMovie();
            return View(topMovies); //look for view name index in movies folder
        }

        [Route("genre/{genreId}")]
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }

        public ActionResult Details(int id)
        {
           /* int x = 0;
            int y = 12;
            int ans = y / x;
            */
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }
    }
}
