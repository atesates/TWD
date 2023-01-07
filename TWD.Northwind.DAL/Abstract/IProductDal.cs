using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.DataAccess;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.DAL.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }

}
