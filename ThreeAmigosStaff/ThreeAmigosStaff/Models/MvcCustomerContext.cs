using Microsoft.EntityFrameworkCore;

namespace MvcCustomer.Models
{
    public class MvcCustomerContext : DbContext
    {
        public MvcCustomerContext(DbContextOptions<MvcCustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}