using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.WPF.Stores
{
    public  class ProductStore
    {
        public event Action<Product> ProductAdded;

        public void AddProduct(Product product)
        {
            ProductAdded?.Invoke(product);
        }

    }
}
