using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcStaff.Models
{
    public static class StaffSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcStaffContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcStaffContext>>()))
            {
                // Look for any Staff.
                if (context.Staff.Any())
                {
                    return;   // DB has been seeded
                }

                context.Staff.AddRange(
                    new Staff
                    {
                        Name = "Musa Haamwala",
                        Email = "example@1.com",
                        Password = "RomanticComedy",
                        Address = "2 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09722342344",
                        IsManagement = true
                    },

                    new Staff
                    {
                        Name = "Usas Haamwala",
                        Email = "example@3.com",
                        Password = "RomanticComedy",
                        Address = "5 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09722342344",
                        IsManagement = false
                    },

                    new Staff
                    {
                        Name = "Pkmd Haamwala",
                        Email = "example@2.com",
                        Password = "RomanticComedy",
                        Address = "6 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09723342344",
                        IsManagement = false
                    },

                    new Staff
                    {
                        Name = "Lsoij Haamwala",
                        Email = "example@5.com",
                        Password = "RomanticComedy",
                        Address = "5 Tell close",
                        PostCode = "JG3 5BD",
                        Telephone = "09724342344",
                        IsManagement = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}