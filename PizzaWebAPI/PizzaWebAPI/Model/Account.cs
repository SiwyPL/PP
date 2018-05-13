using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    [Table("account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string EmailVerificationHash { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }
        public virtual List<AccountRole> Roles { get; set; }
    }
}
