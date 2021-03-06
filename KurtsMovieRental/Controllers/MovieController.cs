﻿using KurtsMovieRental.Models;
using KurtsMovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KurtsMovieRental.Controllers
{
    public class MovieController : Controller
    {

        MovieServices movieServices = new MovieServices();


        public ActionResult Index()
        {
            var newMovies = movieServices.GetAllMovies();
            return View(newMovies);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var newMovie = new Movie(collection);
            movieServices.CreateMovie(newMovie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = new MovieServices().GetOneMovie(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            //gathers new data inputted
            var updatedMovie = new Movie
            {
                Name = collection["Name"],
                YearReleased = int.Parse(collection["YearReleased"]),
                Director = collection["Director"],
                GenreId = int.Parse(collection["GenreId"]),
                Id = id
            };
            //then saves to database
            new MovieServices().EditMovie(updatedMovie, id);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            movieServices.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }
}
