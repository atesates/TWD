using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Utilities.Results;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int productId);
        IDataResult<Product> GetById(int productId);

        IResult TransactionalOperation(Product product);
    }
}
