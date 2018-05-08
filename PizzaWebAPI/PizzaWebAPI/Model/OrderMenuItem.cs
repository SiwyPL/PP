using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("order_menu_items")]
    public class OrderMenuItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("MenuItemOption")]
        public int MenuItemOptionId { get; set; }
        public int Count { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual Order Order { get; set; }
        public virtual MenuItemOption MenuItemOption { get; set; }
        public virtual ICollection<OrderMenuItemIngredient> OrderMenuItemIngredients { get; set; }
    }
}
