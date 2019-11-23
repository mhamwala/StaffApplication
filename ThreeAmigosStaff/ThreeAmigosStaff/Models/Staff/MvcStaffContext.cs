using Microsoft.EntityFrameworkCore;

namespace MvcStaff.Models
{
    public class MvcStaffContext : DbContext
    {
        public MvcStaffContext(DbContextOptions<MvcStaffContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
    }
}