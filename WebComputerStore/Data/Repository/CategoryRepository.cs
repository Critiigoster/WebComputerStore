using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Repository
{
    public class CategoryRepository : ICategories
    {
        // Gateway with ApplicationDbContext to work with database
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> Categories =>
            dbContext.Category;

            
          
    }
}
