using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWD.Northwind.Entities.Concrete
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
