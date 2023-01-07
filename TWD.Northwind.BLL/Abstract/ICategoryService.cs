using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Utilities.Results;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
        IResult Add(Category product);
        IResult Update(Category product);
        IResult Delete(int categoryId);
        IDataResult<Category> GetById(int categoryId);

    }
}
