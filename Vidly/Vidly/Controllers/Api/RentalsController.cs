using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public RentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        //Get Api/Retntals
        public IHttpActionResult GetRentalsRecords()
        {
            return Ok();
        }

        //Get Api/Rentals/id
        public IHttpActionResult GetRentalsRecord(int id)
        {
            return Ok();
        }

        //Post Api/Rentals
        [HttpPost]
        public IHttpActionResult CreateRentalsRecord(RentalDto rentalDto)
        {
            var customer = _dbContext.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var movies = _dbContext.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                    return BadRequest("Movie Not Available.");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _dbContext.Rentals.Add(rental);
            }
            _dbContext.SaveChanges();
            return Ok();
        }


        //PUT Api/Rentals/id
        [HttpPut]
        public IHttpActionResult UpdateRentalsRecord(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        // Delete Api/Rentals/id
        [HttpDelete]
        public IHttpActionResult RemoveRentalRecord(int id)
        {
            return Ok();
        }

    }
}
