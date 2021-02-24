using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Interfaces
{
    public interface IAllProducts
    {
        IQueryable<Product> Products {get; }
        // IEnumerable<Product> FavoriteProducts { get; }
        Product GetProductObject(int ProductId);
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);


    }
}
