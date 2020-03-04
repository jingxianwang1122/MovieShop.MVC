using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        [HttpGet]
        // GET: Cast
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       /* public ActionResult Create(string Name, string Gender, string ProfilePath, string TmdbUrl, string PROFILEPATH, string xyz)
        {
            return View();
        }
        */
        public ActionResult Create(Cast cast)
        {
            return View();
        }


    }
}