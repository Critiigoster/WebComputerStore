﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebComputerStore.Models
{
    public class Product
    {
        public int ProductId { get; set; } // The product ID, primary key, autoincrement
        public string Title { get; set; } //Product title
        public string ShortDescription { get; set; } //A short description that will go to the HTML meta tag

        public string LongDescription { get; set; } //A long description that will go to the HTML meta tag

        public string Image { get; set; } // An (url adress) image of particular product
        public ushort Price { get; set; } // Product price 

        public bool IsFavorite { get; set; }

        public bool  Available { get; set; }

        // Two properties for assigning object to particular category
        public int CategoryId { get; set; }
 
        public Category Category { get; set; }
        // Category has only one category

    }
}