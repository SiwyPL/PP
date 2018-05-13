using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("menu_items_-_ingredients")]
    public class MenuItem_Ingredient
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
