using PizzaWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI
{
    public static class Utils
    {
        public static double DistanceFromCoords(this Restaurant r, double[] coords) {
            var R = 6371e3;
            var φ1 = Math.PI / 180 * coords[0];
            var φ2 = Math.PI / 180 * r.CoordX;
            var Δφ = Math.PI / 180 * (r.CoordX - coords[0]);
            var Δλ = Math.PI / 180 * (r.CoordY - coords[1]);

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) + Math.Cos(φ1) * Math.Cos(φ2) * Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }
    }
}
