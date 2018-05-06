using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAPI.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountsRoles { get; set; }
        public DbSet<Employee_Data> Employees_Data { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Menu_Items> Menu_Items { get; set; }
        public DbSet<Menu_Item_Ingredients> Menu_Item_Ingredients { get; set; }
        public DbSet<Menu_Item_Options> Menu_Item_Options { get; set; }
        public DbSet<Order_Menu_Items> Order_Menu_Items { get; set; }
        public DbSet<Order_Menu_Item_Ingredients> Order_Menu_Ingredients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Restaurants> Restauraunts { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Payment_Type> Payment_Type { get; set; }
    }
}
