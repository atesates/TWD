using System.Collections.Generic;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.MVCUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}