using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThreeAmigosStaff.Services;
using ThreeAmigosProduct.Services;
using ThreeAmigosCustomer.Services;
using ThreeAmigosPurchase.Services;
using ThreeAmigosOrder.Services;
using ThreeAmigosReview.Services;
using System;
using Polly;
using System.Net.Http;

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (_env.IsDevelopment())
            {
                services.AddTransient<IStaffService, FakeStaffService>();
                services.AddTransient<IProductService, FakeProductService>();
                services.AddTransient<ICustomerService, FakeCustomerService>();
                services.AddTransient<IPurchaseService, FakePurchaseService>();
                services.AddTransient<IOrderService, FakeOrderService>();
                services.AddTransient<IReviewService, FakeReviewService>();
            }
            else
            {
                services.AddHttpClient<IReviewService, ReviewService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
                services.AddHttpClient<IStaffService, StaffService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
                services.AddHttpClient<IProductService, ProductService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
                services.AddHttpClient<ICustomerService, CustomerService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
                services.AddHttpClient<IPurchaseService, PurchaseService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
                services.AddHttpClient<IOrderService, OrderService>().AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
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
