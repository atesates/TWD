using System.Collections.Generic;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.MVCUI.Models
{
    public class CategoryListViewModel
    {
        public int CurrentCategory;

        public List<Category> Categories { get; set; }
    }
}