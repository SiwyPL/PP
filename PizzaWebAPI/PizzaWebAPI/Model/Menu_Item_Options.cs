using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Menu_Item_Options")]
    public class Menu_Item_Options
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public int Order_Menu_Id { get; set; }
        public virtual Menu_Items Menu_Item { get; set; }
        [ForeignKey("Order_Menu_Id")]
        public virtual Order_Menu_Items Order_Menu_Item { get; set; }

    }
}
