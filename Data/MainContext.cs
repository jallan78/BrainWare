using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=BrainWAre;Integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }    

        public DbSet<OrderProduct> OrderProduct { get; set; }

        public DbSet<Company> Company { get; set; }
    }
}
