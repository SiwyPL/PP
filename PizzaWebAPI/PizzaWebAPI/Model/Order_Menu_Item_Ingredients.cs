using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Order_Menu_Item_Ingredients")]
    public class Order_Menu_Item_Ingredients
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order_Menu_Items")]
        public int Order_Menu_Item_Id { get; set; }
        [ForeignKey("Ingredients")]
        public int Ingredient_Id { get; set; }

        public virtual Order_Menu_Items Order_Menu_Item { get; set; }
        public virtual Ingredients Ingredient { get; set;}
    }
}
