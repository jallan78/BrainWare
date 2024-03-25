using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
    {
        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }    

        public DbSet<OrderProduct> OrderProduct { get; set; }

        public DbSet<Company> Company { get; set; }
    }
}
