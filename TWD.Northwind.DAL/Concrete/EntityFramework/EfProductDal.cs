using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.DataAccess.EntityFramework;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.DAL.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

    }
}
