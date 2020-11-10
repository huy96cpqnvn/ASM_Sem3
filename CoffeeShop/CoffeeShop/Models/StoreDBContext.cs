
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
