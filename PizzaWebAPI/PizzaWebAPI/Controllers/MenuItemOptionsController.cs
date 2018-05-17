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
    [Route("api/MenuItemOptions")]
    public class MenuItemOptionsController : Controller
    {
        private readonly ModelContext _context;

        public MenuItemOptionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/MenuItemOptions
        [HttpGet]
        public IEnumerable<MenuItemOption> GetMenuItemOptions()
        {
            return _context.MenuItemOptions;
        }

        // GET: api/MenuItemOptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItemOption = await _context.MenuItemOptions.SingleOrDefaultAsync(m => m.Id == id);

            if (menuItemOption == null)
            {
                return NotFound();
            }

            return Ok(menuItemOption);
        }

        // PUT: api/MenuItemOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItemOption([FromRoute] int id, [FromBody] MenuItemOption menuItemOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuItemOption.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuItemOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemOptionExists(id))
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

        // POST: api/MenuItemOptions
        [HttpPost]
        public async Task<IActionResult> PostMenuItemOption([FromBody] MenuItemOption menuItemOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MenuItemOptions.Add(menuItemOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItemOption", new { id = menuItemOption.Id }, menuItemOption);
        }

        // DELETE: api/MenuItemOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItemOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItemOption = await _context.MenuItemOptions.SingleOrDefaultAsync(m => m.Id == id);
            if (menuItemOption == null)
            {
                return NotFound();
            }

            _context.MenuItemOptions.Remove(menuItemOption);
            await _context.SaveChangesAsync();

            return Ok(menuItemOption);
        }

        private bool MenuItemOptionExists(int id)
        {
            return _context.MenuItemOptions.Any(e => e.Id == id);
        }
    }
}