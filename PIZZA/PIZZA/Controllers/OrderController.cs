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
    public class OrderController : ControllerBase
    {
        private readonly s17874Context _context;

        public OrderController(s17874Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var r = _context.Order.Include(p => p.OrderPizza).Select(s => new
            {
                order = s,
                pizzas = _context.Pizza.Where(p => s.OrderPizza.Count(w => w.Pizza == p.IdPizza) > 0).ToList()
            }).ToList();

            return Ok(r);

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
        public IActionResult SendOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return StatusCode(201, order);
        }



    }
}