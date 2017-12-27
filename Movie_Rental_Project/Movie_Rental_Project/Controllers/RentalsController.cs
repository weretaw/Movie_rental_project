using Movie_Rental_Project.Logic;
using Movie_Rental_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Rental_Project.Controllers
{
    public class RentalsController : Controller
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        ReuseRentalFunction reuseRntalFunction = new ReuseRentalFunction();
        // GET: Rentals
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Rentals> rentals = m_db.Rentals;
            return View(rentals);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ReantMovie(int ID)
        {
            Movies movie = m_db.Movies.Find(ID);
            var user = User.Identity;
            reuseRntalFunction.rentNewMovie(movie, user);
            m_db.Movies.Remove(movie);
            m_db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}