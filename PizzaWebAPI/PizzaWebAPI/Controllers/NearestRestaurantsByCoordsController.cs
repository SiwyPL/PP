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
    [Route("api/NearestRestaurantsByCoords")]
    public class NearestRestaurantsByCoordsController : Controller {
        private readonly ModelContext _context;

        public NearestRestaurantsByCoordsController(ModelContext context) {
            _context = context;
        }

        [HttpGet("{coordsString}")]
        public async Task<Object> GetRestauraunts([FromRoute] string coordsString) {

            double[] coords = coordsString.Split(",").Select(c => double.Parse(c.Replace('.', ','))).ToArray();

            IEnumerable<Object> list = new List<Object>();

            await Task.Run(() => {
                list = _context.Restauraunts.Select(r => new { Restaurant = r, Distance = r.DistanceFromCoords(coords) }).ToList();
            });


            return new { List = list, FormattedAddress = $"{coords[0].ToString().Replace(',', '.')}, {coords[1].ToString().Replace(',', '.')}", status = "OK" };
        }
    }
}