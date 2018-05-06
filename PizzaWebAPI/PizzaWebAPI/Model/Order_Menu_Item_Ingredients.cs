using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Order_Menu_Item_Ingredients
    {
        public int Id { get; set; }
        public int Order_Menu_Item_Id { get; set; }
        public int Ingredient_Id { get; set; }

        public virtual Order_Menu_Items Order_Menu_Item { get; set; }
        public virtual Ingredients Ingredient { get; set;}
    }
}
