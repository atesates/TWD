using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.MVCUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
    }
}
