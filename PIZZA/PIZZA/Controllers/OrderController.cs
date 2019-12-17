using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public IActionResult SendOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return StatusCode(201, order);
        }


    }
}