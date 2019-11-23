using Microsoft.EntityFrameworkCore;

namespace MvcPurchase.Models
{
    public class MvcPurchaseContext : DbContext
    {
        public MvcPurchaseContext(DbContextOptions<MvcPurchaseContext> options)
            : base(options)
        {
        }

        public DbSet<Purchase> Purchase { get; set; }
    }
}