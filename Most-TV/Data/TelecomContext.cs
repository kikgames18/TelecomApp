using Microsoft.EntityFrameworkCore;
using TelecomApp.Models;

namespace TelecomApp.Data
{
    public class TelecomContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=myuser;Password=mypassword;Database=TelecomDb");
        }
    }
}