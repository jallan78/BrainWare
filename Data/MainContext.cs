using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var mdf = @"C:\temp\BrainWare\BrainWare\Api\data\BrainWare.mdf";
            var connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }    

        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
