using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Ingredients")]
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public virtual ICollection<Menu_Item_Ingredients> Menu_Item_Ingredients { get; set; }
        public virtual ICollection<Order_Menu_Item_Ingredients> Order_Menu_Item_Ingredients { get; set; }

    }
}
