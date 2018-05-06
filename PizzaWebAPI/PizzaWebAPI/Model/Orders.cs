using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public int Status_Id { get; set; }
        public decimal Total_Price { get; set; }
        public DateTime Date { get; set; }
        public int Employee_Id { get; set; }
        public int Payment_Type_Id { get; set; }

        public virtual Status Status { get; set; }
        public virtual Payment_Type Payment_Type { get; set; }
        public virtual Employee_Data Employee { get; set; }
        public virtual ICollection<Order_Menu_Items> Order_Menu_Items { get; set; }

    }
}
