using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcPurchase.Models
{
    public static class PurchaseSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPurchaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPurchaseContext>>()))
            {
                // Look for any Purchase.
                if (context.Purchase.Any())
                {
                    return;   // DB has been seeded
                }

                context.Purchase.AddRange(
                    new Purchase
                    {
                        Id = 21,
                        ProductName = "Ballons",
                        UserId = 1,
                        UserName = "Musa Hamwala",
                        Quantity = 23,
                        Date = 22/04/2019,
                        Price = 14.23,
                        Accepted = false
                    },

                    new Purchase
                    {
                        Id = 22,
                        ProductName = "Fish",
                        UserId = 2,
                        UserName = "James Liddle",
                        Quantity = 14,
                        Date = 22/04/2019,
                        Price = 14.23,
                        Accepted = false
                    },

                    new Purchase
                    {
                        Id = 23,
                        ProductName = "Carrots",
                        UserId = 3,
                        UserName = "Nathan Williams",
                        Quantity = 100,
                        Date = 22/04/2019,
                        Price = 14.23,
                        Accepted = false
                    },

                    new Purchase
                    {
                        Id = 24,
                        ProductName = "Chicken",
                        UserId = 4,
                        UserName = "Conner Basket",
                        Quantity = 2,
                        Date = 22/04/2019,
                        Price = 14.23,
                        Accepted = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}