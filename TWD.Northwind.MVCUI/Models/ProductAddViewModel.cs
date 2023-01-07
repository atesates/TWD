using System.Collections.Generic;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.MVCUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}