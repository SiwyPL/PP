using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaWebAPI.Model;

namespace PizzaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderMenuItem_Ingredient")]
    public class OrderMenuItem_IngredientController : Controller
    {
        private readonly ModelContext _context;

        public OrderMenuItem_IngredientController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/OrderMenuItem_Ingredient
        [HttpGet]
        public IEnumerable<OrderMenuItem_Ingredient> GetOrderMenuItems_Ingredients()
        {
            return _context.OrderMenuItems_Ingredients;
        }

        // GET: api/OrderMenuItem_Ingredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderMenuItem_Ingredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMenuItem_Ingredient = await _context.OrderMenuItems_Ingredients.SingleOrDefaultAsync(m => m.Id == id);

            if (orderMenuItem_Ingredient == null)
            {
                return NotFound();
            }

            return Ok(orderMenuItem_Ingredient);
        }

        // PUT: api/OrderMenuItem_Ingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMenuItem_Ingredient([FromRoute] int id, [FromBody] OrderMenuItem_Ingredient orderMenuItem_Ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderMenuItem_Ingredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderMenuItem_Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMenuItem_IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderMenuItem_Ingredient
        [HttpPost]
        public async Task<IActionResult> PostOrderMenuItem_Ingredient([FromBody] OrderMenuItem_Ingredient orderMenuItem_Ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderMenuItems_Ingredients.Add(orderMenuItem_Ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMenuItem_Ingredient", new { id = orderMenuItem_Ingredient.Id }, orderMenuItem_Ingredient);
        }

        // DELETE: api/OrderMenuItem_Ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMenuItem_Ingredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMenuItem_Ingredient = await _context.OrderMenuItems_Ingredients.SingleOrDefaultAsync(m => m.Id == id);
            if (orderMenuItem_Ingredient == null)
            {
                return NotFound();
            }

            _context.OrderMenuItems_Ingredients.Remove(orderMenuItem_Ingredient);
            await _context.SaveChangesAsync();

            return Ok(orderMenuItem_Ingredient);
        }

        private bool OrderMenuItem_IngredientExists(int id)
        {
            return _context.OrderMenuItems_Ingredients.Any(e => e.Id == id);
        }
    }
}