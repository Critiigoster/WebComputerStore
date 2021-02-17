using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Repository
{

    

    public class ProductRepository : IAllProducts
    {


        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> Products =>
            dbContext.Product.Include(c =>
            c.Category); 
        public Product GetProductObject(int ProductId)
        =>
           dbContext.Product.FirstOrDefault(p =>
            p.ProductId == ProductId); 
        
    }
}
