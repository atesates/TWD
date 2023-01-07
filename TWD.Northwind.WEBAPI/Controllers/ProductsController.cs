using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace TWD.Northwind.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
   

        [HttpGet(template:"getlist")]
        //[Authorize(Roles = "Product.List")]
       // [Authorize]
        public IActionResult GetList()
        {
            var result = _productService.GetList();  
            if(result.Success)
            {
                return Ok(result.Data); 
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template:"add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "delete")]
        public IActionResult Delete(int productId)
        {
            var result = _productService.Delete(productId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
