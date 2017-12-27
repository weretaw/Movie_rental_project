using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental_Project.Models
{
    public class Rentals
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int MoviesID { get; set; }
        public string MovieName { get; set; }
        public string Category { get; set; }
    }
}