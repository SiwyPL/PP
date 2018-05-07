using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Status")]
        public int Status_Id { get; set; }
        public decimal Total_Price { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Employee_Data")]
        public int Employee_Id { get; set; }
        [ForeignKey("Payment_Type")]
        public int Payment_Type_Id { get; set; }

        public virtual Status Status { get; set; }
        public virtual Payment_Type Payment_Type { get; set; }
        public virtual Employee_Data Employee { get; set; }
        public virtual ICollection<Order_Menu_Items> Order_Menu_Items { get; set; }

    }
}
