using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Restaurants
    {
        public int Id { get; set;}
        public String Name { get; set; }
        public float CoordX { get; set; }
        public float CoordY { get; set;}
        public String Adress { get; set; }
        public String City { get; set; }
        public String Phone { get; set; }
        public virtual ICollection<Menu_Items> Menu_Items { get; set; }
        public virtual ICollection<Employee_Data> Employee { get; set; }

    }
}
