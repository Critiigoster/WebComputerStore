using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products {get; }
        // IEnumerable<Product> FavoriteProducts { get; }
        Product GetProductObject(int ProductId); 



    }
}
