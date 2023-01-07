using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Entities;

namespace TWD.Northwind.Entities.Concrete
{
    public class Category :IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
