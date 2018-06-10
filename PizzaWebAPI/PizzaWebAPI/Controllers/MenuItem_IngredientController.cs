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
    [Route("api/MenuItem_Ingredient")]
    public class MenuItem_IngredientController : Controller
    {
        private readonly ModelContext _context;

        public MenuItem_IngredientController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/MenuItem_Ingredient
        [HttpGet]
        public IEnumerable<MenuItem_Ingredient> GetMenuItems_Ingredients()
        {
            return _context.MenuItems_Ingredients;
        }

        // GET: api/MenuItem_Ingredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItem_Ingredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItem_Ingredient = await _context.MenuItems_Ingredients
                .Include(mii => mii.Ingredient)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (menuItem_Ingredient == null)
            {
                return NotFound();
            }

            return Ok(menuItem_Ingredient);
        }

        // PUT: api/MenuItem_Ingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem_Ingredient([FromRoute] int id, [FromBody] MenuItem_Ingredient menuItem_Ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuItem_Ingredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuItem_Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItem_IngredientExists(id))
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

        // POST: api/MenuItem_Ingredient
        [HttpPost]
        public async Task<IActionResult> PostMenuItem_Ingredient([FromBody] MenuItem_Ingredient menuItem_Ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MenuItems_Ingredients.Add(menuItem_Ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItem_Ingredient", new { id = menuItem_Ingredient.Id }, menuItem_Ingredient);
        }

        // DELETE: api/MenuItem_Ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem_Ingredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItem_Ingredient = await _context.MenuItems_Ingredients.SingleOrDefaultAsync(m => m.Id == id);
            if (menuItem_Ingredient == null)
            {
                return NotFound();
            }

            _context.MenuItems_Ingredients.Remove(menuItem_Ingredient);
            await _context.SaveChangesAsync();

            return Ok(menuItem_Ingredient);
        }

        private bool MenuItem_IngredientExists(int id)
        {
            return _context.MenuItems_Ingredients.Any(e => e.Id == id);
        }
    }
}