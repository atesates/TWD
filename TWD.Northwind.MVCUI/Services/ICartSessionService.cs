using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.MVCUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
