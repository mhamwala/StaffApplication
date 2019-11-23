using Microsoft.EntityFrameworkCore;

namespace MvcProduct.Models
{
    public class MvcProductContext : DbContext
    {
        public MvcProductContext(DbContextOptions<MvcProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}