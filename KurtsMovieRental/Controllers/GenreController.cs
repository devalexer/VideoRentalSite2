using KurtsMovieRental.Models;
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
            var newGenres = genreServices.GetAllGenres();
            return View(newGenres);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var newGenre = new Genre(collection);
            genreServices.CreateGenre(newGenre);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = new GenreServices().GetOneGenre(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            //gathers new data inputted
            var updatedGenre = new Genre
            {
                Name = collection["Name"],
                Id = id
            };
            //then saves to database
            new GenreServices().EditGenre(updatedGenre, id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var genre = genreServices.GetAllGenres().First(f => f.Id == id);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Delete(Genre genre)
        {
            genreServices.DeleteGenre(genre);
            return RedirectToAction("Index");
        }
    }
}
