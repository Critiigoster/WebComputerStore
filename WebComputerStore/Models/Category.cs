using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebComputerStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Descriprion { get; set; }

        public List<Product> products { get; set; }
        // Category has many objects of its class

    }
}
