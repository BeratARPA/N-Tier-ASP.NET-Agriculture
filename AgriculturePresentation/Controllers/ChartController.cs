using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : Controller
    {
        private readonly IProductService _productService;

        public ChartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            List<Product> products = new List<Product>();
            var productList = _productService.GetAll();

            foreach (Product product in productList)
            {
                products.Add(new Product
                {
                    ProductId = product.ProductId,
                    name = product.name,
                    value = product.value
                });
            }

            return Json(new { jsonlist = products });
        }
    }
}