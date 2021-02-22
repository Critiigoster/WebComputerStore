using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.ViewModel
{
    public class ProductListViewModel
    {
      public IEnumerable<Product> _Products { get; set;  }

       public string CurrentCategory { get; set; }

    }
}
