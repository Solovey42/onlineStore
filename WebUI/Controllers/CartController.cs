using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        readonly ApplicationContext _context;
        Cart cart;

        public CartController(ApplicationContext context)
        {
            _context = context;
        }

        public ViewResult CartView(string returnUrl, int? code)
        {
            cart = GetCart();
            return View(new CartViewModel { Cart = cart, ReturnUrl = returnUrl, Code = code });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl, int quantity)
        {
            cart = GetCart();
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                if(cart.CartDetail.Contains(cart.CartDetail.Where(cartDetail => cartDetail.ProductId == productId).FirstOrDefault()))
                {
                    CartDetail cartDetail = _context.CartDetails.FirstOrDefault(cartDetail => cartDetail.Cart == cart && cartDetail.Product == product);
                    cartDetail.Quantity += quantity;
                    _context.SaveChanges();
                    return RedirectToAction("CartView", "Cart", new { returnUrl = returnUrl, code = 1 });
                }
                else
                {
                    _context.CartDetails.Add(
                       new CartDetail
                       {
                           CartId = cart.Id,
                           Cart = cart,
                           ProductId = product.Id,
                           Product = product,
                           Quantity = quantity
                       });
                    _context.SaveChanges();
                    cart = GetCart();
                }
            }
            return RedirectToAction("CartView", "Cart", new { returnUrl = returnUrl });
        }

        public ActionResult EditProduct(int productId, int newQuantity, string returnUrl)
        {
            if (newQuantity > 0 && newQuantity < 10001 && newQuantity !=0)
            {
                Product product = _context.Products
               .FirstOrDefault(p => p.Id == productId);

                if (product != null)
                {
                    cart = GetCart();
                    CartDetail cartDetail = _context.CartDetails.FirstOrDefault(p => p.Cart == cart && p.Product == product);
                    cartDetail.Quantity = newQuantity;
                    _context.SaveChanges();
                }
                return RedirectToAction("CartView", "Cart", new { returnUrl = returnUrl });
            }
            return RedirectToAction("CartView", "Cart", new { returnUrl = returnUrl, code = 2 });
        }

        public RedirectToActionResult RemoveProduct(int productId, string returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                cart = GetCart();
                CartDetail cartDetail = _context.CartDetails.FirstOrDefault(p => p.Cart == cart && p.Product == product);
                _context.CartDetails.Remove(cartDetail);
                _context.SaveChanges();
            }
            return RedirectToAction("CartView", "Cart", new { returnUrl = returnUrl });
        }

        public Cart GetCart()
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            var cart = _context.Carts.Include(t => t.CartDetail).FirstOrDefault(c => c.User == user);
            var cartDetail = _context.CartDetails.Include(t => t.Product).ToList();

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = user.Id,
                    User = user
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
                return cart;
            }
            return cart;
        }
    }
}
