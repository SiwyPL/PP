using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountsRoles { get; set; }
    }
}
