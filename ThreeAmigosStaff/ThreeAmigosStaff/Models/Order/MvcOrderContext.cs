using Microsoft.EntityFrameworkCore;
namespace MvcOrder.Models
{
    public class MvcOrderContext : DbContext
    {
        public MvcOrderContext(DbContextOptions<MvcOrderContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Order { get; set; }
    }
}