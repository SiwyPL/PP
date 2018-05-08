using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("menu_item_options")]
    public class MenuItemOption
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public int Order_Menu_Id { get; set; }
        public virtual MenuItem Menu_Item { get; set; }
        [ForeignKey("Order_Menu_Id")]
        public virtual OrderMenuItem Order_Menu_Item { get; set; }

    }
}
