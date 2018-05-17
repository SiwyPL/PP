using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("restaurants")]
    public class Restaurant
    {
        [Key]
        public int Id { get; set;}
        public String Name { get; set; }
        public float CoordX { get; set; }
        public float CoordY { get; set;}
        public String Address { get; set; }
        public String City { get; set; }
        public String Phone { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<EmployeeData> Employees { get; set; }

    }
}
