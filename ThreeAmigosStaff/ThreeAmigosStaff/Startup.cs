﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MvcPurchase.Models;
using MvcOrder.Models;
using ThreeAmigosStaff.Services;
using ThreeAmigosProduct.Services;
using ThreeAmigosCustomer.Services;
using ThreeAmigosPurchase.Services;

namespace ThreeAmigosStaff
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _env = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment _env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MvcOrderContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("OrderContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (_env.IsDevelopment())
            {
                services.AddTransient<IStaffService, FakeStaffService>();
                services.AddTransient<IProductService, FakeProductService>();
                services.AddTransient<ICustomerService, FakeCustomerService>();
                services.AddTransient<IPurchaseService, FakePurchaseService>();
            }
            else
            {
                services.AddHttpClient<IStaffService, StaffService>();
                services.AddHttpClient<IProductService, ProductService>();
                services.AddHttpClient<ICustomerService, CustomerService>();
                services.AddHttpClient<IPurchaseService, PurchaseService>();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
