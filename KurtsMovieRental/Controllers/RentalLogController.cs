using KurtsMovieRental.Models;
using KurtsMovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KurtsMovieRental.Controllers
{
    public class RentalLogController : Controller
    {

        MovieServices movieServices = new MovieServices();


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(movie);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //accept & parse the input (formcollection)
            var updatedMovie = new Movie(collection);

            //save it to our database
            //redirect to the correct page
            return RedirectToAction("Index");
        }
    }
}
