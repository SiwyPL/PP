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
        public DbSet<EmployeeData> EmployeesData { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItem_Ingredient> MenuItemIngredients { get; set; }
        public DbSet<MenuItemOption> MenuItemOptions { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<OrderMenuItem_Ingredient> OrderMenuIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restauraunts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
