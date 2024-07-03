using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapi.Models;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private static List<Shirt> shirts = new List<Shirt>
        {
            new Shirt { Id = 1, Brand = "My Brand 1", Colour = "Red", Size = 5, Gender = "Male", Price = 100 },
            new Shirt { Id = 2, Brand = "My Brand 2", Colour = "Blue", Size = 6, Gender = "Female", Price = 150 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Shirt>> GetShirts()
        {
            return Ok(shirts);
        }

        [HttpGet("{id}")]
        public ActionResult<Shirt> GetShirtByID(int id)
        {
            var shirt = shirts.FirstOrDefault(s => s.Id == id);
            if (shirt == null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }

        [HttpPost]
        public ActionResult<Shirt> CreateShirt([FromBody] Shirt shirt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            shirt.Id = shirts.Any() ? shirts.Max(s => s.Id) + 1 : 1;
            shirts.Add(shirt);
            return CreatedAtAction(nameof(GetShirtByID), new { id = shirt.Id }, shirt);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateShirt(int id, [FromBody] Shirt shirt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingShirt = shirts.FirstOrDefault(s => s.Id == id);
            if (existingShirt == null)
            {
                return NotFound();
            }
            existingShirt.Brand = shirt.Brand;
            existingShirt.Colour = shirt.Colour;
            existingShirt.Size = shirt.Size;
            existingShirt.Gender = shirt.Gender;
            existingShirt.Price = shirt.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteShirt(int id)
        {
            var shirt = shirts.FirstOrDefault(s => s.Id == id);
            if (shirt == null)
            {
                return NotFound();
            }
            shirts.Remove(shirt);
            return NoContent();
        }
    }
}
