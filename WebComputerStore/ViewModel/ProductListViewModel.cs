using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.ViewModel
{
    public class ProductListViewModel 
    {
      public IQueryable<Product> _Products { get; set;  }

        public PagingInfo PagingInfo { get; set; }
       public string CurrentCategory { get; set; }
    }
}
