using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace Vidly.Controllers.api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext db;

        public CustomerController()
        {
            db=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        
        public IHttpActionResult GetCustomers(string term=null)
        {
            var customers = db.Customers.Include(c => c.Membership);
            
            if(!string.IsNullOrWhiteSpace(term))
                customers = customers.Where(c=>c.CustomerName.Contains(term));

            var customerDto = customers.ToList().Select(Mapper.Map<Customers, CustomersDto>);
            return Ok(customerDto);
        }

        [HttpGet]
        public CustomersDto GetCustomer(int id)
        {
            var cust = db.Customers.SingleOrDefault(c => c.Id == id);
            return Mapper.Map<Customers,CustomersDto>(cust);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomers(CustomersDto customersDto)
        {
            var customer = Mapper.Map<CustomersDto, Customers>(customersDto);
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customersDto);
        }

        [HttpPut]
        public void UpdateCustomer(CustomersDto customersDto)
        {
            var custDtoDemo = Mapper.Map<CustomersDto, Customers>(customersDto);//By this way we can create a customer object, access data from the DTO object and remaining is same
            var customerInDb = db.Customers.Find(custDtoDemo.Id);

            if (customerInDb == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    customerInDb.BirthDate = custDtoDemo.BirthDate;
                    customerInDb.CustomerName = custDtoDemo.CustomerName;
                    customerInDb.MembershipTypeId = custDtoDemo.MembershipTypeId;
                    customerInDb.IsSubscribedToNewsletter = custDtoDemo.IsSubscribedToNewsletter;

                    db.SaveChanges();
                }
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }
        }



    }
}
