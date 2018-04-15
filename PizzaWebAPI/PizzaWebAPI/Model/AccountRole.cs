using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
    }
}
