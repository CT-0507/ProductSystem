using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSystem.Models;
using ProductSystem.Services;
using System;

namespace ProductSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            try
            {
                model.ProductList = _productService.GetAllProduct();
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            ProductViewModel model = new ProductViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult ProductDetail(string id)
        {
            EditProductViewModel editProductView = new EditProductViewModel();
            if (!string.IsNullOrEmpty(id))
            {
                editProductView.Product = _productService.GetProductById(id);
                editProductView.Mode = "Edit";
                ViewData["Title"] = "Edit";
            }
            else
            {
                editProductView.Product = new Product();
                editProductView.Mode = "Add new Product";
                ViewData["Title"] = "Add new Product";
            }
            
            return View(editProductView);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel editProductView)
        {
            switch(editProductView.Mode)
            {
                case "Edit":
                    _productService.UpdateProduct(editProductView.Product, 1);
                    break;
                case "Add new Product":
                    _productService.AddNewProduct(editProductView.Product, 1);
                    break;
                case "Delete":
                    _productService.DeleteProduct(editProductView.Product.Id, 1);
                    break;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewProduct() 
        {
            return RedirectToAction("ProductDetail", "Product");
        }


    }
}
