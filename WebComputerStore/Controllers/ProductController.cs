using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.ViewModel;

namespace WebComputerStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IAllProducts allProducts;
        private readonly ICategories allCategories;
        public int PageSize = 6; // The field specifies that I want four products per page.



        public ProductController(IAllProducts allProducts, ICategories allCategories)
        {
            this.allProducts = allProducts;
            this.allCategories = allCategories;

        }
        public IActionResult List(int productPage = 1)
        {
            // Working through view models 
            // using WebComputerStore.ViewModel
            ProductListViewModel obj =
                new ProductListViewModel();

            obj._Products = allProducts.Products.
                OrderBy(p=> p.ProductId)
                .Skip((productPage-1)*PageSize)
                .Take(PageSize);
            obj.PagingInfo = new PagingInfo
            {

                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = allProducts.Products.Count()
            };

            obj.CurrentCategory = "Technique";
            return View(obj);
        }

      

    }
}
