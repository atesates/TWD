using System;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.Concrete;
using TWD.Northwind.DAL.Concrete.EntityFramework;

namespace TWD.Northwind.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            IProductService _productService = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            foreach (var product in _productService.GetList().Data)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        }
    }
}
