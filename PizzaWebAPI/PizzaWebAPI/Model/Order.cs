using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("EmployeeData")]
        public int EmployeeId { get; set; }
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual Status Status { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual EmployeeData Employee { get; set; }
        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}
