using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("employee_data")]
    public class EmployeeData
    {
        [Key]
        public int Id { get; set; }
        public String Phone { get; set; }
        public String Position { get; set; }
        [ForeignKey("AccountRole")]
        public int AccountRoleId { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual AccountRole AccountRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
