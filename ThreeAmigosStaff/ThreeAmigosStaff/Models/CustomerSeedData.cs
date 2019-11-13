using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcCustomer.Models
{
    public static class CustomerSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCustomerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCustomerContext>>()))
            {
                // Look for any Customers.
                if (context.Customer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Customer.AddRange(
                    new Customer
                    {
                        Name = "Musa Haamwala",
                        Email = "example@1.com",
                        Password = "RomanticComedy",
                        Address = "2 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09722342344"
                    },

                    new Customer
                    {
                        Name = "Usas Haamwala",
                        Email = "example@3.com",
                        Password = "RomanticComedy",
                        Address = "5 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09722342344"
                    },

                    new Customer
                    {
                        Name = "Pkmd Haamwala",
                        Email = "example@2.com",
                        Password = "RomanticComedy",
                        Address = "6 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09723342344"
                    },

                    new Customer
                    {
                        Name = "Lsoij Haamwala",
                        Email = "example@5.com",
                        Password = "RomanticComedy",
                        Address = "5 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09724342344"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}