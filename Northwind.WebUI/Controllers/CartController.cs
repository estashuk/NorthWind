using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;

namespace Northwind.WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository _productRepository = new ProductRepository();

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ActionResult AddToCart(Cart cart, int productId)
        {
            Products product = _productRepository.Products
                .FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
                cart.AddItem(product, 1);
            return PartialView(cart);
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout(Cart cart)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry your cart is empty");
            }
            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View("CartIsEmpty");
            }
        }
    }
}