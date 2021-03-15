
 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebComputerStore.Infrastructure;
using WebComputerStore.Models;
using System.Linq;
using WebComputerStore.Data.Interfaces;

namespace WebComputerStore.Pages
{

 public class CartModel : PageModel
    {
        private IAllProducts repository;
        public CartModel(IAllProducts repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductId == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Product.ProductId == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}
