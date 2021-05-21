using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[Authorize(Roles = "Admin, User")]
/*        public IActionResult Index()
        {
            // string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value; только там где требуется роль админа
            //return Content($"ваша роль: {role}");
            return RedirectToAction("Catalog");
        }*/

        public IActionResult Catalog()
        {
            var categoryOfProduct = _context.CategoryOfProducts.Include(t => t.TypeOfProducts).ToList();
            //var typeOfProducts = _context.TypeOfProducts.Include(t => t.Products).ToList();
            //var products = _context.Products.Include(p => p.TypeOfProduct).ToList();
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value; только там где требуется роль админа
            //return Content($"ваша роль: {role}");
            return View(categoryOfProduct);
        }

        [HttpGet]
        public IActionResult ProductList(int id)
        {
            var products = _context.Products.Include(p => p.TypeOfProduct).ToList().Where(a => a.TypeOfProductId == id);
            List<Product> list = products.ToList();
            return View(new ProductListViewModel(list, null, null));
        }

        [HttpPost]
        public IActionResult ProductList(int id, int selectedProductId, string returnUrl, [FromForm] ProductListViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddToCart", "Cart", new { productId = selectedProductId, returnUrl = returnUrl, quantity = model.Quantity });
            }
            var products = _context.Products.Include(p => p.TypeOfProduct).ToList().Where(a => a.TypeOfProductId == id);
            List<Product> list = products.ToList();
            return View(new ProductListViewModel(list, null, selectedProductId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            var users = _context.Users.Include(u => u.Orders).ToList();
            return View(users);
        }
    }
}