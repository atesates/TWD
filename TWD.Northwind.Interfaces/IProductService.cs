using System;
using System.Collections.Generic;
using System.Text;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product Get(int productId);

        void Add(Product product);

        void Delete(int productId);

        void Update(Product product);

    }
}
