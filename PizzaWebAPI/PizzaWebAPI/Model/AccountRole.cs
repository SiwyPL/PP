using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("accounts_roles")]
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        [ForeignKey("EmployeeData")]
        public int EmployeeId { get; set; }
        public virtual EmployeeData Employee { get; set; }
        //public virtual Account Account { get; set; }
    }
}
