using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Menu_Items")]
    public class Menu_Items
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        [ForeignKey("Restaurants")]
        public int Restaurant_Id { get; set; }
        public bool Has_Ingredients{ get; set; }

        public virtual ICollection<Menu_Item_Ingredients> Menu_Item_Ingredients { get; set; }
        public virtual ICollection<Order_Menu_Items> Order_Menu_Items { get; set; }
        public virtual ICollection<Menu_Item_Options> Menu_Item_Options { get; set; }
        public virtual Restaurants Restaurant { get; set; }
    }
}
