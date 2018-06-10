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
    [Route("api/OrderMenuItems")]
    public class OrderMenuItemsController : Controller
    {
        private readonly ModelContext _context;

        public OrderMenuItemsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/OrderMenuItems
        [HttpGet]
        public IEnumerable<OrderMenuItem> GetOrderMenuItems()
        {
            return _context.OrderMenuItems;
        }

        // GET: api/OrderMenuItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderMenuItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMenuItem = await _context.OrderMenuItems
                .Include(omi => omi.MenuItemOption)
                .Include(omi => omi.MenuItemOption)
                .Include(omi => omi.OrderMenuItemIngredients)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (orderMenuItem == null)
            {
                return NotFound();
            }

            return Ok(orderMenuItem);
        }

        // PUT: api/OrderMenuItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMenuItem([FromRoute] int id, [FromBody] OrderMenuItem orderMenuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderMenuItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMenuItemExists(id))
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

        // POST: api/OrderMenuItems
        [HttpPost]
        public async Task<IActionResult> PostOrderMenuItem([FromBody] OrderMenuItem orderMenuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderMenuItems.Add(orderMenuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMenuItem", new { id = orderMenuItem.Id }, orderMenuItem);
        }

        // DELETE: api/OrderMenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMenuItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMenuItem = await _context.OrderMenuItems.SingleOrDefaultAsync(m => m.Id == id);
            if (orderMenuItem == null)
            {
                return NotFound();
            }

            _context.OrderMenuItems.Remove(orderMenuItem);
            await _context.SaveChangesAsync();

            return Ok(orderMenuItem);
        }

        private bool OrderMenuItemExists(int id)
        {
            return _context.OrderMenuItems.Any(e => e.Id == id);
        }
    }
}