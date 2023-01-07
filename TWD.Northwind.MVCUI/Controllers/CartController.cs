using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.MVCUI.Models;
using TWD.Northwind.MVCUI.Services;

namespace TWD.Northwind.MVCUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(
            ICartSessionService cartSessionService,
            ICartService cartService,
            IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }
        
        public ActionResult AddToCart(int productID)
        {
            var productToBeAdded = _productService.GetById(productID);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded.Data);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your product, {0}, was successfully added to the cart!", productToBeAdded.Data.ProductName));

            return RedirectToAction("Index", "Product");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was successfully removed from the cart!"));
            return RedirectToAction("List");
        }


        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank you {0}, you order is in process", shippingDetails.FirstName));
            return View();
        }
    }
}