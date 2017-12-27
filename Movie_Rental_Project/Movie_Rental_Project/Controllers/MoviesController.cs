using Movie_Rental_Project.Logic;
using Movie_Rental_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Rental_Project.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies 
        ApplicationDbContext m_db = new ApplicationDbContext();

        ReuseMovieFunction reuseMovieFunction = new ReuseMovieFunction();
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Movies> movies = m_db.Movies;
            return View(movies);
        }

        //Cerate new movie
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //Cerate new movie
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(string MovieName, string Category)
        {
            reuseMovieFunction.createMovie(MovieName, Category);
            return RedirectToAction("Index");
        }

        //Update movie
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Update(int Id)
        {
            Movies movies = m_db.Movies.Find(Id);
            ViewBag.ID = movies.ID;
            ViewBag.MovieName = movies.MovieName;
            ViewBag.Category = movies.Category;
            return View();
        }

        //Update movie
        [HttpPost]
        [Authorize(Roles = "admin")]        public ActionResult Update(int MovieId, string MovieName, string MovieCategory)
        {
            reuseMovieFunction.upDateMovie(MovieId, MovieName, MovieCategory);
            return RedirectToAction("Index");
        }

        //Delete movie
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int ID)
        {
            reuseMovieFunction.deleteMovie(ID);
            return RedirectToAction("Index");
        }

    }
}