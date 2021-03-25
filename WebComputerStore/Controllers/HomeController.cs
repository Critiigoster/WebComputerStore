using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Data;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Models;
using WebComputerStore.ViewModel;

namespace WebComputerStore.Controllers
{
    public class HomeController : Controller
    {
        private IAllProducts _repository;

  
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;   }

        public IActionResult Index(string category)
        {

            return RedirectToAction("List", "Product");
        }

        public async Task<IActionResult> Search(string searchString)
        {
            // Working through view models 
            // using WebComputerStore.ViewModel
            ApplicationDbContext obj =
                new ApplicationDbContext();

            var products = from m in obj.Product
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Title.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
