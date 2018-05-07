using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("Employee_Data")]
    public class Employee_Data
    {
        [Key]
        public int Id { get; set; }
        public String Phone { get; set; }
        public String Position { get; set; }
        [ForeignKey("AccountRole")]
        public int AccountRole_Id { get; set; }
        [ForeignKey("Restaurants")]
        public int Restaurant_Id { get; set; }

        public virtual Restaurants Restaurant { get; set; }
        public virtual AccountRole AccountRole { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
