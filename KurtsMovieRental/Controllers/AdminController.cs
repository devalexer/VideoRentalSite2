using KurtsMovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using KurtsMovieRental.Models;

namespace KurtsMovieRental.Controllers
{
    public class AdminController : Controller
    {

        MovieServices movieServices = new MovieServices();
        AdminServices adminServices = new AdminServices();


        public ActionResult Index()
        {
            var movie = new MovieServices().GetAllMovies();
            return View(movie);
        }

    }
}
