﻿using System;
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
    public class PromoController : ControllerBase
    {
        private readonly s17874Context _context;

        public PromoController(s17874Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Promo.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {

            if (!_context.Promo.Any(p => p.IdPromo == id))
            {
                return NotFound();
            }
            return Ok(_context.Promo.Find(id));
        }

        [HttpPost]
        public IActionResult AddItem(Promo newPromo)
        {
            _context.Promo.Add(newPromo);
            _context.SaveChanges();
            return StatusCode(201, newPromo);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateItem(int id, [FromBody]Promo update)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Promo.Any(p => p.IdPromo == id))
            {
                return NotFound();
            }

            _context.Promo.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(update);
        }

        [HttpDelete("id:int")]
        public IActionResult deleteItem(int id)
        {
            var promo = _context.Promo.FirstOrDefault(p => p.IdPromo == id);
            if (promo == null)
            {
                return NotFound();
            }

            _context.Promo.Remove(promo);
            _context.SaveChanges();
            return Ok(promo);
        }

    }
}