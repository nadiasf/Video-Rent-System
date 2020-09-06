using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //Get Api/Customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _dbContext.Customers
                .Include(c => c.MemberShipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery= customersQuery.Where(c => c.Name.Contains(query));

            var customerDto = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDto);
        }

        //Get Api/Customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //Post Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //Put Api/Customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerDb);

            _dbContext.SaveChanges();
            return Ok();
        }

        //Delete Api/Customers/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _dbContext.Customers.Remove(customer);

            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
