using csharp_simple_webapi.Main.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_simple_webapi.Main
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
