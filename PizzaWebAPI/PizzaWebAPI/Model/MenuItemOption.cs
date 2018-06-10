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
        //public virtual MenuItem MenuItem { get; set; }
        //public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }

    }
}
