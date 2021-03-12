using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebComputerStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Descriprion { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public List<Product> products { get; set; }
        // Category has many objects of its class

    }
}
