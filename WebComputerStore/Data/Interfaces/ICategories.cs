using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Interfaces
{
   public interface ICategories
    {
        public IEnumerable<Category> Categories { get; } 
    }
}
