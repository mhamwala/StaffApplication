using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcCustomer.Models;
using MvcOrder.Models;
using MvcProduct.Models;
using MvcPurchase.Models;
using MvcStaff.Models;

namespace ThreeAmigosStaff
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var customerContext = services.GetRequiredService<MvcCustomerContext>();
                    customerContext.Database.Migrate();
                    CustomerSeedData.Initialize(services);

                    var purchaseContext = services.GetRequiredService<MvcPurchaseContext>();
                    purchaseContext.Database.Migrate();
                    PurchaseSeedData.Initialize(services);

                    var orderContext = services.GetRequiredService<MvcOrderContext>();
                    orderContext.Database.Migrate();
                    OrderSeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
