using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("order_menu_item_ingredients")]
    public class OrderMenuItemIngredient
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OrderMenuItem")]
        public int OrderMenuItemId { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public virtual OrderMenuItem OrderMenuItem { get; set; }
        public virtual Ingredient Ingredient { get; set;}
    }
}
