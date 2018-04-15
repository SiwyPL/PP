using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string EmailVerificationHash { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }
        public List<AccountRole> Roles { get; set; }
    }
}
