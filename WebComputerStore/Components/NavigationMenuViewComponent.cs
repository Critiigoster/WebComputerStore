using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using Microsoft.AspNetCore.Mvc;
using WebComputerStore.Data.Interfaces;

namespace WebComputerStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAllProducts repository;
        public NavigationMenuViewComponent(IAllProducts repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Products
            .Select(x => x.Category.CategoryName)
            .Distinct()
            .OrderBy(x => x));
        }
    }

}
