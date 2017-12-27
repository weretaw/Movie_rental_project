using Movie_Rental_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental_Project.Logic
{
    public class ReuseMovieFunction
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        public void createMovie(string _MovieName, string _Category)
        {
            Movies movies = new Movies
            {
                MovieName = _MovieName,
                Category = _Category
            };

            m_db.Movies.Add(movies);
            m_db.SaveChanges();
        }

        public void upDateMovie(int MovieId, string MovieName, string MovieCategory)
        {
            Movies exsistMovie = m_db.Movies.Find(MovieId);
            exsistMovie.MovieName = MovieName;
            exsistMovie.Category = MovieCategory;
            m_db.SaveChanges();
        }


        public void deleteMovie(int ID)
        {
            Movies exsistMovie = m_db.Movies.Find(ID);
            m_db.Movies.Remove(exsistMovie);
            m_db.SaveChanges();
        }
    }
}