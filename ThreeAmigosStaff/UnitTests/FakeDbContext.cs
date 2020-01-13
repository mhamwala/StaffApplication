using ThreeAmigosProduct.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Products
{
    public static class FakeDbContext
    {
        public static productsContext getProductMockDb(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<productsContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new productsContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}