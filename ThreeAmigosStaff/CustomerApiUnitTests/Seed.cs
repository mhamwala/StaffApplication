using ThreeAmigosCustomer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApiUnitTests
{
    public static class seedData
    {
        public static void Seed(this CustomerContext dbContext)
        {
            dbContext.customer.AddRange(
                new CustomerDto { Name = "Musa Haamwala", Email = "example@1.com", Password = "RomanticComedy", Address = "2 Tell close", PostCode = "JG3 5BD", Telephone = "09722342344" },
                new CustomerDto { Name = "Usas Haamwala", Email = "example@3.com", Password = "RomanticComedy", Address = "5 Tell close", PostCode = "JG3 5BD", Telephone = "09722342344" },
                new CustomerDto { Name = "Pkmd Haamwala", Email = "example@2.com", Password = "RomanticComedy", Address = "6 Tell close", PostCode = "JG3 5BD", Telephone = "09723342344" },
                new CustomerDto { Name = "Lsoij Haamwala", Email = "example@5.com", Password = "RomanticComedy", Address = "5 Tell close", PostCode = "JG3 5BD", Telephone = "09724342344" }
                );

            dbContext.SaveChanges();
        }
    }
}