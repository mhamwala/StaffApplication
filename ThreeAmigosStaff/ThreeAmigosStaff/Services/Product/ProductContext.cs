using Microsoft.EntityFrameworkCore;

namespace ThreeAmigosProduct.Services
{
    public class productsContext : DbContext
    {
        public productsContext(DbContextOptions<productsContext> options) : base(options) { }
        public DbSet<ProductDto> product { get; set; }
        public DbSet<ReviewDto> review { get; set; }
        public DbSet<ProductHistoryDto> productHistory { get; set; }
    }
}
