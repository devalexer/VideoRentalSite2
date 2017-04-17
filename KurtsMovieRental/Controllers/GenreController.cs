using KurtsMovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KurtsMovieRental.Controllers
{
    public class GenreController : Controller
    {

        GenreServices genreServices = new GenreServices();


        public ActionResult Index()
        {
            var newMovies = genreServices.GetAllGenres();
            return View(newMovies);
        }
    }
}
