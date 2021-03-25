using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputerStore.Models;
using Microsoft.EntityFrameworkCore.SqlServer; 


namespace WebComputerStore.Data
{
    //IdentityDbContext implements DbContext
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             Database.EnsureCreated();   // create database when first time occuring
        }
        

        // These properties allow to represent collection of objects related to particular table in database
        public DbSet<Category> Category { get; set;  }
        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Orders { get; set; }




    }
}
