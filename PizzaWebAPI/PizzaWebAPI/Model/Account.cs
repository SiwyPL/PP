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
        [RegularExpression(@"^[a-z0-9]{2,30}$", ErrorMessage = "Invalid login format (small letters and numbers, from 2 up to 30 characters).")]
        public string Login { get; set; }
        [RegularExpression(@"^[a-fA-F0-9]{64}$", ErrorMessage = "Invalid password hash.")]
        public string Password { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\._\-]+@[A-Za-z0-9\.\-]+[\.][A-Za-z]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-fA-F0-9]{64}$", ErrorMessage = "Invalid email verification hash.")]
        public string EmailVerificationHash { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }
        public virtual List<AccountRole> Roles { get; set; }
    }
}
