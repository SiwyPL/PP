using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Menu_Item_Ingredients
    {
        public int Menu_Item_Id { get; set; }
        public int Ingredient_Id { get; set; }
        public virtual Menu_Items Menu_Items_Id { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
