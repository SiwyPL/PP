using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaWebAPI.Model;

namespace PizzaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/NearestRestaurants")]
    public class NearestRestaurantsController : Controller
    {
        private readonly ModelContext _context;

        public NearestRestaurantsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/NearestRestaurants/{address}
        [HttpGet("{address}")]
        public async Task<Object> GetRestauraunts([FromRoute] string address)
        {
            var json_data = string.Empty;

            using (var w = new WebClient()) {
                // attempt to download JSON data as a string
                try {
                    json_data = w.DownloadString($"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyBs2AOh7DdQ9BRPUG1I3PW6tvh-RElL_u0");
                } catch (Exception) { }
            }

            dynamic json_obj = JObject.Parse(json_data);
            //Console.WriteLine(json_obj.status);

            double[] coords = new double[2];

            try {
                coords[0] = json_obj.results.geometry.location.lat;
                coords[1] = json_obj.results.geometry.location.lng;
            } catch (Exception) {
                //Console.WriteLine(json_obj.error_message);
                //Console.WriteLine(json_obj.status);
                return new { error = json_obj.error_message, json_obj.status };
            }

            string status = json_obj.status;

            IEnumerable<Object> list = new List<Object>();

            await Task.Run(() => {
                list = _context.Restauraunts.Select(r => new { Restaurant = r, Distance = r.DistanceFromCoords(coords), Status = status }).ToList();
            });


            return new { List = list, FormattedAddress = json_obj.results.formatted_address }; 
        }

    }
}