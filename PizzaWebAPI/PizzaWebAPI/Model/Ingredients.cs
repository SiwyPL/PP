using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Ingredients
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public virtual ICollection<Menu_Item_Ingredients> Menu_Item_Ingredients { get; set; }
        public virtual ICollection<Order_Menu_Item_Ingredients> Order_Menu_Item_Ingredients { get; set; }

    }
}
