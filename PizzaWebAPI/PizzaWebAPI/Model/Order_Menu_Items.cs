using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Order_Menu_Items")]
    public class Order_Menu_Items
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Menu_Items")]
        public int Menu_Item_Id { get; set; }
        [ForeignKey("Orders")]
        public int Order_Id { get; set; }
        [ForeignKey("Menu_Item_Options")]
        public int Menu_Item_Option_Id { get; set; }
        public int Count { get; set; }
        public virtual Menu_Items Menu_Item { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Menu_Item_Options Menu_Item_Option { get; set; }
        public virtual ICollection<Order_Menu_Item_Ingredients> Order__Menu_Item_Ingredients { get; set; }

    }
}
