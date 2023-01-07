using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.MVCUI.Models;

namespace TWD.Northwind.MVCUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetList().Data,
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
            };
            return View(model);
        }
    }
}
