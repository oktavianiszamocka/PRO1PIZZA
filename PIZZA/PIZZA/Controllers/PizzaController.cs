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
    public class PizzaController : ControllerBase
    {
        private readonly s17874Context _context;

        public PizzaController(s17874Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            if (!_context.Pizza.Any(p => p.IdPizza == id))
            {
                return NotFound();
            }

            return Ok(_context.Pizza.Find(id));
        }
     
        [HttpPost]
        public IActionResult AddItem(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();
            return StatusCode(201, newPizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateItem(int id, [FromBody]Pizza update)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (!_context.Pizza.Any(p => p.IdPizza == id))
            {
                return NotFound();
            }
            
            _context.Pizza.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(update);
        }

        [HttpDelete("id:int")]
        public IActionResult deleteItem(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(p => p.IdPizza == id);
            if( pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();
            return Ok(pizza);
        }

    }
}