using ProductSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSystem.Services
{
    public class ProductService : IProductService
    {
        private static  List<Product> productList = new List<Product>()
        {
            new Product() {Id = "001", Name = "Galaxy Note 10", Category = "Phone", Description = "Phone from Samsung", Price = 2000, ProviderId = 1},
            new Product() {Id = "002", Name = "IPhone 14", Category = "Phone", Description = "Phone from Apple", Price = 4000, ProviderId = 2},
            new Product() {Id = "003", Name = "Nokia A1", Category = "Phone", Description = "Phone from Nokia", Price = 2000, ProviderId = 4},
            new Product() {Id = "004", Name = "Macbook Pro", Category = "Tablet", Description = "Tablet from Apple", Price = 2000, ProviderId = 2},
            new Product() {Id = "005", Name = "Asus Rog 14", Category = "Laptop", Description = "Laptop from Asus", Price = 5000, ProviderId = 3},
            new Product() {Id = "006", Name = "Samsung", Category = "Phone", Description = "Phone from Samsung", Price = 2500, ProviderId = 1},
            new Product() {Id = "007", Name = "Samsung", Category = "Phone", Description = "Phone from Samsung", Price = 2500, ProviderId = 1, DeleteYMD = DateTime.Now},
        };

        public List<Product> GetAllProduct()
        {
            List<Product> products = productList.Where(x => x.DeleteYMD.HasValue == false).ToList(); ;
            
            return products;
        }

        public void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public Product GetProductById(string id)
        {
            return productList.Find(x => x.Id == id);
        }

        public void UpdateProduct(Product product, int userId)
        {
            var targetProduct = productList.FirstOrDefault(item => item.Id == product.Id);
            targetProduct.Name = product.Name;
            targetProduct.Category = product.Category;
            targetProduct.Description = product.Description;
            targetProduct.Price = product.Price;
        }

        public void DeleteProduct(string id, int userId)
        {
            var target = productList.FirstOrDefault(item => item.Id == id);
            target.DeleteYMD = DateTime.Now;
        }

        public void AddNewProduct(Product product, int userId)
        {
            product.Id = $"00{productList.Count()}";
            productList.Add(product);

        }
    }
}
