using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.ViewModel;

namespace WebComputerStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IAllProducts allProducts;
        private readonly ICategories allCategories;


        public ProductController(IAllProducts allProducts, ICategories allCategories)
        {
            this.allProducts = allProducts;
            this.allCategories = allCategories;

        }
        public IActionResult List()
        {
            // Working through view models 
            // using WebComputerStore.ViewModel
            ProductListViewModel obj =
                new ProductListViewModel();
            obj._Products = allProducts.Products;
            obj.CurrentCategory = "Technique";
            return View(obj);
        }
    }
}
