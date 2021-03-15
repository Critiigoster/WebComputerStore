using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Data.Repository;
using WebComputerStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


namespace WebComputerStore
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment configuration)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(configuration.ContentRootPath).
                AddJsonFile("appsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddMvcCore();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            /*services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            */
            services.AddRazorPages();//  sets up the services used by Razor Pages

            // creates a service where each HTTP request gets its own repository object, 
            // which is the way that Entity  Framework Core is typically used.
            services.AddScoped<ICategories, CategoryRepository>();
            services.AddScoped<IAllProducts, ProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddScoped<IOrder, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor(); // creates the services that Blazor uses

            services.AddDistributedMemoryCache(); // method call sets up the in-memory data store
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePages(); // For Pages with codes 404, 200 etc..


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("catpage",
                 "{category}/Page{productPage:int}",
                 new { Controller = "Product", action = "List" });

                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                new { Controller = "Product", action = "List", productPage = 1 });

                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Product", action = "List", productPage = 1 });

                endpoints.MapControllerRoute("pagination",
                "Products/Page{productPage}",
                new { Controller = "Product", action = "List", productPage = 1 });


                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages(); // registers Razor Pages as endpoints that the URL routing system can use to handle requests.


                endpoints.MapBlazorHub(); // registers the Blazor middleware components
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");     
                // Addition is to finesse the routing system to ensure that Blazor works seamlessly with the rest of  the application.


               


            });


            DbObjects.Initial(app);



            /*
            using (var scope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbObjects.Initial(context);
            }
            
            */
        }
    }
}
