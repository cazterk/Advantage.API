using Advantage.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Advantage.API.Demo.Controllers
{
    [Route("api/[controller]/")]
    public class CustomerController : Controller
    {
        private readonly APIContext _ctx;

        public CustomerController(APIContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = _ctx.Customers.OrderBy(c => c.Id);

            return Ok(data);
        }



        [HttpGet("{id}", Name = "GetCustomer")]
        public Customer Get(int id)
        {
            return _ctx.Customers.Find(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

    }


}