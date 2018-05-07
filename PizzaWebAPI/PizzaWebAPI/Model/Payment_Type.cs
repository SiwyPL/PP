using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Payment_Type")]
    public class Payment_Type
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Orders Order { get; set; }
    }
}
