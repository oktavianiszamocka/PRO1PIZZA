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
    public class ToppingController : ControllerBase
    {
        private readonly s17874Context _context;

        public ToppingController(s17874Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Topping.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            if(!_context.Topping.Any(t => t.IdTopping == id))
            {
                return NotFound();
            }

            return Ok(_context.Topping.Find(id));
        }
    }
}