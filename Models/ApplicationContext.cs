
using Microsoft.EntityFrameworkCore;


 
namespace SuperPuperTaxi.Models
{
    public class ApplicationContext : DbContext 
    {
        public DbSet<Order> Orders { get ; set; }
        public DbSet<TaxiDriver> TaxiDrivers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
