using ThreeAmigosCustomer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApiUnitTests
{
    public static class FakeDbContext
    {
        public static CustomerContext GetCustomerMockDb(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseSqlite("Data Source=Database.db")
                .Options;

            // Create instance of DbContext
            var dbContext = new CustomerContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}