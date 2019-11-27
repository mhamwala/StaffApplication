﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcStaff.Models;
using MvcCustomer.Models;
using Microsoft.EntityFrameworkCore;
using MvcPurchase.Models;
using MvcProduct.Models;
using MvcOrder.Models;
using ThreeAmigosStaff.Services;

namespace ThreeAmigosStaff
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MvcStaffContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("StaffContext")));

            services.AddDbContext<MvcCustomerContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("CustomerContext")));

            services.AddDbContext<MvcPurchaseContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("PurchaseContext")));

            services.AddDbContext<MvcProductContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("ProductContext")));

            services.AddDbContext<MvcOrderContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("OrderContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (Environment.IsDevelopment())
            {
                services.AddTransient<IStaffService, FakeStaffService>();
            }
            else
            {
                services.AddHttpClient<IStaffService, FakeStaffService>();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

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
