using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebComputerStore.Models;

namespace WebComputerStore.Data
{
    public class DbObjects
    {
        // Static lets to get method instantly
        // Method allows to get objects from database and write in it.
        public static void Initial(ApplicationDbContext Content)
        {
           //  ApplicationDbContext Content =
                   // application.ApplicationServices.GetRequiredService<ApplicationDbContext>();


            if (!Content.Category.Any())
                Content.Category.AddRange(Categories.Select(c =>
                c.Value));
            // Create range of object to and fro database (if any)


            if (!Content.Product.Any())
            {
                Content.AddRange(
                    
                    new Product { 
                    Title = "Lenovo IdeaPad 1", 
                    ShortDescription = "Laptop for work",
                    LongDescription = "Whether you are looking to stream your favorite movies, play your favorite games or get down to work, IdeaPad has a laptop for you with top-notch performance at any budget", 
                    Price = 193.99m, 
                    Available = true,
                    IsFavorite = false,
                    Image = "https://static.lenovo.com/na/subseries/hero/ideapad-1-11-intel-ice-blue-hero.png",
                    Category = Categories["Computers"]
                    
                   
                    },

                    new Product
                    {
                        Title = "NVIDIA GeForce GTX 1050 Ti",
                        ShortDescription = "4GB GDDR5 128 Bit PCI-E Graphic Card",
                        LongDescription = "New NVIDIA pascal architecture delivers improved performance and power efficiency " +
                        "Classic and modern games at 1080P at 60 FPS" +
                        "Fast, smooth, power - efficient gaming experiences.Support up to 8K display at 60Hz",
                        Price = 299.99m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://images-na.ssl-images-amazon.com/images/I/91wSunpXgpL._AC_SL1500_.jpg",
                        Category = Categories["Video Cards"]

                    },

                    new Product
                    {
                        Title = "MacBook Air",
                        ShortDescription = "Power. It’s in the Air.",
                        LongDescription = "Our thinnest, lightest notebook, completely transformed by the Apple M1 chip. CPU speeds up to 3.5x faster. GPU speeds up to 5x faster. Our most advanced Neural Engine for up to 9x faster machine learning. The longest battery life ever in a MacBook Air. And a silent, fanless design. This much power has never been this ready to go.",
                        Price = 999.99m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://www.notebookcheck-ru.com/uploads/tx_nbc2/air13teaser.jpg",
                        Category = Categories["Apple"]

                    },

                    new Product
                    {
                        Title = "AMD Ryzen 5000 Series",
                        ShortDescription = "AMD Ryzen Desktop Processors",
                        LongDescription = "Whether you are playing the latest games, designing the next skyscraper, or crunching data, you need a powerful processor that can handle it all—and more. Hands down, the AMD Ryzen 5000 Series desktop processors set the bar for gamers and artists alike.",
                        Price = 879.95m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://www.amd.com/system/files/styles/992px/private/2020-10/648625-vermeer-black-chip-render-1260x709_2.png?itok=b6PL7Emc",
                        Category = Categories["Processors"]

                    },

                    new Product
                    {
                        Title = "SAMSUNG 870 QVO SATA III 2.5",
                        ShortDescription = "Solid State Drive - 1TB",
                        LongDescription = "GO BIG, DO MORE: The 870 QVO is Samsung’s latest 2nd generation QLC SSD with up to 8TB of storage capacity",
                        Price = 109.95m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://images-na.ssl-images-amazon.com/images/I/91S1PIX%2ByWL._AC_SL1500_.jpg",
                        Category = Categories["SSDs&HardDrives"]

                    },

                    new Product
                    {
                        Title = "Corsair Vengeance LPX 16GB",
                        ShortDescription = "Corsair Vengeance LPX 16GB (2x8GB) DDR4 DRAM 3200MHz C16 Desktop Memory Kit - Black",
                        LongDescription = "Hand-sorted memory chips ensure high performance with generous Overclocking headroom. Available in multiple colors to match the style of your system",
                        Price = 89.98m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://images-na.ssl-images-amazon.com/images/I/51kHiPeTSmL._AC_SL1000_.jpg",
                        Category = Categories["RAM"]

                    },

                    new Product
                    {
                        Title = "LG 27UN850-W 27",
                        ShortDescription = "Ultra HD Monitor for creators",
                        LongDescription = "LG 27UN850-W 27 Inch Ultrafine UHD (3840 x 2160) IPS Display with VESA DisplayHDR 400, USB Type-C and 3-Side Virtually Borderless Display with Height/Swivel/Pivot/Tilt Adjustable Stand, Silver",
                        Price = 194.99m,
                        Available = true,
                        IsFavorite = false,
                        Image = "https://images-na.ssl-images-amazon.com/images/I/81kVFBp13RL._AC_SL1500_.jpg",
                        Category = Categories["Monitors"]

                    });

            }

            Content.SaveChanges(); // Saves all products and categories; 
        }


        /*_________________________________________________________________________*/


        private static Dictionary<string, Category> _category;
            public static Dictionary<string, Category> Categories{
            get {
                if (_category == null) // If category is full then it's not working. We return these objects
                {

                    var list = new Category[]
                        {

                            new Category {CategoryName = "Computers", Descriprion = "Computers and Laptops"  },
                            new Category {CategoryName = "Apple", Descriprion = "Apple computers, IPads, IPods, IPhones and other Accessories"  },
                            new Category {CategoryName = "Video Cards", Descriprion = "Best videocards for your graphics"  },
                            new Category {CategoryName = "SSDs&HardDrives", Descriprion = "HDD or SSD Memory for your devices"  },
                            new Category {CategoryName = "Processors", Descriprion = "Give heart to your machine"  },
                            new Category {CategoryName = "Power Supplies", Descriprion = "Give life to your computer"  },
                            new Category {CategoryName = "Air&WaterCooling", Descriprion = "Don't forget to cool your machine"  },
                            new Category {CategoryName = "Wireless Networking", Descriprion = "Wi-FI and other solution for internet accessing"  },
                            new Category {CategoryName = "RAM", Descriprion = "Random Access Memory for your device"  },
                            new Category {CategoryName = "Monitors", Descriprion = "Large variety of displays for your comfy work"  }

                        };


                    _category = new Dictionary<string, Category>(); // allocate memory for our list 
                    foreach (Category item in list)
                        _category.Add(item.CategoryName, item); // string key and value

                }

                return _category; // Return list


            }
            
        
        }

        
        
    }
}
