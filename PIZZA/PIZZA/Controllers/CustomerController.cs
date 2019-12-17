using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIZZA.Models;

namespace PIZZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly s17874Context _context;

        public CustomerController(s17874Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Customer.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            if (!_context.Customer.Any(p => p.IdCustomer == id))
            {
                return NotFound();
            }
            return Ok(_context.Customer.Find(id));
        }

        [HttpPost]
        public IActionResult AddCus(Customer newCus)
        {
            _context.Customer.Add(newCus);
            _context.SaveChanges();
            return StatusCode(201, newCus);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateItem(int id, [FromBody]Customer update)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Customer.Any(p => p.IdCustomer == id))
            {
                return NotFound();
            }

            _context.Customer.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(update);
        }

        [HttpDelete("id:int")]
        public IActionResult deleteCus(int id)
        {
            var customer = _context.Customer.FirstOrDefault(p => p.IdCustomer == id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
    }
}