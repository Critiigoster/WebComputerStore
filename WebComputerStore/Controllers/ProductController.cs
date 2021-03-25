using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Models;
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
        public IActionResult List(string category, int productPage = 1)
        {
            // Working through view models 
            // using WebComputerStore.ViewModel
            ProductListViewModel obj =
                new ProductListViewModel();

            obj._Products = allProducts.Products.
                Where(p=> category == null || p.Category.CategoryName == category).
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


        public IActionResult Search(string searchString, int productPage = 1)
        {


            var products = from m in allProducts.Products select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Title == searchString);
            }


            // Working through view models 
            // using WebComputerStore.ViewModel
            ProductListViewModel obj =
                new ProductListViewModel();

            obj._Products = allProducts.Products.
                Where(s => s.Title.Contains(searchString));

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
