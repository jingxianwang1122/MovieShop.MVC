using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        // GET: Genres
        public PartialViewResult Index() //returning a partial view, creating a hyperlink, sending a list of genres
        {
            return PartialView("GenresView", _genreService.GetAllGenres().OrderBy(g => g.Name).ToList());
        }
    }
}