using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebComputerStore.Data
{
    public class DbObjects
    {
        // Static lets to get method instantly
        // Method allows to get objects from database and write in it.
        public static void Initial(IApplicationBuilder application)
        {
            ApplicationDbContext DbContent =
                   application.ApplicationServices.GetRequiredService<ApplicationDbContext>(); 

        
        
        
        }
    }
}
