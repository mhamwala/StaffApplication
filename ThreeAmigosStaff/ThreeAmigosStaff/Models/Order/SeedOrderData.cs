using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace MvcOrder.Models
{
    public static class OrderSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcOrderContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcOrderContext>>()))
            {
                // Look for any Orders.
                if (context.Order.Any())
                {
                    return;   // DB has been seeded
                }
                context.Order.AddRange(
                    new Order
                    {
                        CustomerID = 22
                    },
                    new Order
                    {
                        CustomerID = 23
                    },
                    new Order
                    {
                        CustomerID = 24
                    },
                    new Order
                    {
                        CustomerID = 25
                    }
                );
                context.SaveChanges();
            }
        }
    }
}