using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("payment_types")]
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        
        public virtual ICollection<Order> Order { get; set; }
    }
}
