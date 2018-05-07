using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("AccountRole")]
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Employee_Data")]
        public int Employee_Id { get; set; }
        public virtual Employee_Data Employee { get; set; }
        public virtual Account Account { get; set; }
    }
}
