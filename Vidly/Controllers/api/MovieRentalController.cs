using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MovieRentalController : ApiController
    {
        private ApplicationDbContext db;

        public MovieRentalController()
        {
            db=new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize(Roles = UserRole.CanManageMovies)]
        public IHttpActionResult CreateRental(MovieRentalDto movieRental)
        {
            var customer = db.Customers.Find(movieRental.CustomerId);

            foreach (var movieId in movieRental.MovieId)
            {
                var movie = db.Movies.Find(movieId);
                if(movie==null)
                    throw new Exception(HttpStatusCode.BadRequest.ToString());

                var movieRentalObj=new MovieRental();
                movieRentalObj.Customers = customer;
                movieRentalObj.Movies = movie;
                movieRentalObj.Movies.Available = movieRentalObj.Movies.Available - 1;
                movieRentalObj.RentalDate = DateTime.Now;

                db.MovieRentals.Add(movieRentalObj);
            }

            db.SaveChanges();

            return Ok();
        }

    }
}
