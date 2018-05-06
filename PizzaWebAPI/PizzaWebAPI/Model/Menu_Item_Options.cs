using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Menu_Item_Options
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }

        public virtual Menu_Items Menu_Item { get; set; }
        public virtual Order_Menu_Items Order_Menu_Item { get; set; }

    }
}
