using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaWebAPI.Model;

namespace PizzaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly ModelContext _context;

        public StatisticsController(ModelContext context) {
            _context = context;
        }


        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStats([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            Object stats = null;

            switch (id) {

                // ilość zamówień wg dni tygodnia
                case 1: stats = await _context.Orders
                        .GroupBy(o => DateTimeFormatInfo.CurrentInfo.GetDayName(o.Date.DayOfWeek))
                        .Select(g => new { DayOfWeek = g.Key, Orders = g.Count() })
                        .OrderBy(s => s.DayOfWeek)
                        .ToListAsync();
                    break;

                // ilość zamówień wg restauracji
                case 2: stats = await _context.Orders
                        .GroupBy(o => o.RestaurantId)
                        .Select(g => new { RestaurantId = g.Key, Orders = g.Count() })
                        .Join(_context.Restauraunts, g => g.RestaurantId, r => r.Id, (g, r) => new { RestaurantName = r.Name, Orders = g.Orders })
                        .OrderByDescending(s => s.Orders)
                        .ToListAsync();
                    break;

                default:
                    break;
            }



            if (stats == null) {
                return NotFound();
            }

            return Ok(stats);
        }
    }
}