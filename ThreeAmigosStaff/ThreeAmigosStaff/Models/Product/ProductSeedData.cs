using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcProduct.Models
{
    public static class ProductSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcProductContext>>()))
            {
                // Look for any Product.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Id = 21,
                        Name = "Ballons",
                        Price = 1,
                        Stock = 3
                    },

                    new Product
                    {
                        Id = 22,
                        Name = "Kite",
                        Price = 10.30,
                        Stock = 4
                    },

                    new Product
                    {
                        Id = 23,
                        Name = "Phone",
                        Price = 19.23,
                        Stock = 3
                    },

                    new Product
                    {
                        Id = 24,
                        Name = "Wallet",
                        Price = 1.99,
                        Stock = 30
                    }
                );
                context.SaveChanges();
            }
        }
    }
}