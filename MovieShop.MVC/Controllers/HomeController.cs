using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService) //injecting dependency
        {
            _movieService = movieService;
        }

        [HttpGet]   //the method will be execute when we put [HttpGet]
        public ActionResult Index() //action method
        {
            var topMovies = _movieService.GetTopRenevueMovie();
            return View(topMovies); //html page: we can have as many view as possible
            //look for views folder, then look for controller name (which is home) folder, look for view cshtml with same name as action method name
        }
        [HttpGet]
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }
        public ActionResult About()    
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}