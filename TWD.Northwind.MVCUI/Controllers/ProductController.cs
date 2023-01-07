using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.MVCUI.Models;

namespace TWD.Northwind.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page = 1, int categoryId = 0)
        {
            int pageSize = 10;
            var products = _productService.GetListByCategory(categoryId).Data;

            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = categoryId,
                CurrentPage = page
            };
            return View(model);
        }
        //public string Session()
        //{
        //    HttpContext.Session.SetString("city", "Ankara");
        //    HttpContext.Session.SetInt32("age", 44);

        //    HttpContext.Session.GetInt32("age");
        //    HttpContext.Session.GetString("city");
        //}

    }
}