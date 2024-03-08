using ProductSystem.Models;
using System.Collections.Generic;

namespace ProductSystem.Services
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
        Product GetProductById(string id);
        void UpdateProduct(Product product, int userId);
        void DeleteProduct(string id, int userId);
        void AddNewProduct(Product product, int userId);
    }
}
