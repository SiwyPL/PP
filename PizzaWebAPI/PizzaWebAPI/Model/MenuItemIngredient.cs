using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("menu_item_ingredients")]
    public class MenuItemIngredient
    {
        [Key]
        [ForeignKey("Menu_Items")]
        public int Menu_Item_Id { get; set; }
        [ForeignKey("Ingredients")]
        public int Ingredient_Id { get; set; }
        public virtual MenuItem Menu_Items_Id { get; set; }
        public virtual Ingredient Ingredients { get; set; }
    }
}
