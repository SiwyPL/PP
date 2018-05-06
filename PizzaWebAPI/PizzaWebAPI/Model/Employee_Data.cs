using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Employee_Data
    {
        public int Id { get; set; }
        public String Phone { get; set; }
        public String Position { get; set; }
        public int Restaurant_Id { get; set; }

        public virtual Restaurants Restaurant { get; set; }
        public virtual AccountRole AccountRole { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
