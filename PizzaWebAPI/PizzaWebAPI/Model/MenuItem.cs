using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("menu_items")]
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public bool HasIngredients{ get; set; }

        public virtual ICollection<MenuItem_Ingredient> MenuItemIngredients { get; set; }
        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
        public virtual ICollection<MenuItemOption> MenuItemOptions { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
