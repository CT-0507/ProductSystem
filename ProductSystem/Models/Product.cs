using Microsoft.VisualBasic;
using System;

namespace ProductSystem.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int ProviderId { get; set;}

        public DateTime? DeleteYMD { get; set; }

        public Product()
        {
            Id = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            Price = 0;
            ProviderId = 0;
            DeleteYMD = null;

        }
    }
}
