using Movie_Rental_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Movie_Rental_Project.Logic
{
    public class ReuseRentalFunction
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        //rent new movie methode
        public void rentNewMovie(Movies getMovie, IIdentity user)
        {
            Rentals rentmovie = new Rentals
            {
                MoviesID = getMovie.ID,
                UserName = user.Name,
                MovieName = getMovie.MovieName,
                Category = getMovie.Category
            };
            m_db.Rentals.Add(rentmovie);
            m_db.SaveChanges();
        }
    }
}