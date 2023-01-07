using Microsoft.AspNetCore.Mvc;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "delete")]
        public IActionResult Delete(int categoryId)
        {
            var result = _categoryService.Delete(categoryId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
