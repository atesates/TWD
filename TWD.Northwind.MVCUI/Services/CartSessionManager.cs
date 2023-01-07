using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.MVCUI.ExtensionsMethods;
using Microsoft.AspNetCore.Http;

namespace TWD.Northwind.MVCUI.Services
{
    public class CartSessionManager : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.setObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }

            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.setObject("cart", cart);
        }
    }
}
