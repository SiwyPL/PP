using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Menu_Item_Ingredients")]
    public class Menu_Item_Ingredients
    {
        [ForeignKey("Menu_Items")]
        public int Menu_Item_Id { get; set; }
        [ForeignKey("Ingredients")]
        public int Ingredient_Id { get; set; }
        public virtual Menu_Items Menu_Items_Id { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
