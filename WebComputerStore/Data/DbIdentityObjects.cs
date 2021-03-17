using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebComputerStore.Data
{
    public class DbIdentityObjects
    {

        private const string adminUser = "Admin";
        private const string adminPassword = "AdminIhor321";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationIdentityDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<ApplicationIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user != null)
            {
                user = new IdentityUser("Admin");
                user.Email = "begroom@gmail.com";
                user.PhoneNumber = "380957161955";
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
