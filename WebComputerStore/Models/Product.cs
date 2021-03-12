using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebComputerStore.Models
{
    public class Product 
    {
        public int ProductId { get; set; } // The product ID, primary key, autoincrement

        [Required(ErrorMessage = "Please enter a product title")]
        public string Title { get; set; } //Product title

        [Required(ErrorMessage = "Please enter a description")]
        public string ShortDescription { get; set; } //A short description that will go to the HTML meta tag

        public string LongDescription { get; set; } //A long description that will go to the HTML meta tag

        public string Image { get; set; } // An (url adress) image of particular product

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
         [Column(TypeName = "decimal(8, 2)")]

        public decimal Price { get; set; } // Product price 

        public bool IsFavorite { get; set; }

        public bool  Available { get; set; }

        // Two properties for assigning object to particular category
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please specify a category")]

        [JsonIgnore]
        [IgnoreDataMember]
        public Category Category { get; set; }
        // Category has only one category

    }
}
