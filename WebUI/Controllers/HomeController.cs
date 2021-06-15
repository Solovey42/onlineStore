using ClosedXML.Excel;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineStore.Models;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminView()
        {
            List<User> users = _context.Users.Include(user => user.Orders).OrderBy(user => user.Id).ToList();
            List<Product> products = _context.Products.Include(product => product.TypeOfProduct).OrderBy(product => product.Id).ToList();
            List<Order> orders = _context.Orders.Include(order => order.OrderDetails).OrderBy(order => order.Id).ToList();
            return View(new AdminPageModel(users, products, orders));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminView([FromForm] AdminPageModel model, int productId)
        {
            if (ModelState.IsValid)
            {
                Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    if (model.Name != null)
                        product.Name = model.Name;
                    if (model.Size != null)
                        product.Size = model.Size;
                    if (model.Cost > 0 && model.Cost < 10001 && model.Cost != 0)
                        product.Cost = model.Cost;
                    else
                        return RedirectToAction("AdminView", "Home");
                    _context.SaveChanges();
                }
                return RedirectToAction("AdminView", "Home");
            }
            List<User> users = _context.Users.Include(user => user.Orders).OrderBy(user => user.Id).ToList();
            List<Product> products = _context.Products.Include(product => product.TypeOfProduct).OrderBy(product => product.Id).ToList();
            List<Order> orders = _context.Orders.Include(order => order.OrderDetails).OrderBy(order => order.Id).ToList();
            return View(new AdminPageModel(users, products, orders));
            
        }
        public RedirectToActionResult RemoveProduct(int productId)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminView", "Home");
        }

        [HttpPost]
        public string Import(IFormFile fileExcel)
        {
            string s1 = "", s2 = "", s3 = "", s4 = "";
            //PriceViewModel viewModel = new PriceViewModel();
            using (XLWorkbook workBook = new XLWorkbook(fileExcel.OpenReadStream(), XLEventTracking.Disabled))
            {
                foreach (IXLWorksheet worksheet in workBook.Worksheets)
                {
                    Product product = new Product();
                    s1 = worksheet.Name;

                    foreach (IXLColumn column in worksheet.ColumnsUsed().Skip(1))
                    {
                        Product product2 = new Product();
                        s2 = column.Cell(1).Value.ToString();

                        foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                        {
                            try
                            {
                                Product product3 = new Product();
                                s3 = row.Cell(1).Value.ToString();
                                s4 = row.Cell(column.ColumnNumber()).Value.ToString();

                            }
                            catch (Exception e)
                            {
                                //logging
                            }
                        }

                        //phoneBrand.PhoneModels.Add(phoneModel);
                    }
                   /// viewModel.PhoneBrands.Add(phoneBrand);
                }
            }
            return $"строки: {s1} {s2} {s3} {s4}";
/*            return RedirectToAction("AdminView", "Home");*/
        }

        public ActionResult Export()
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Brands");

                worksheet.Cell("A1").Value = "Бренд";
                worksheet.Cell("B1").Value = "Модели";
                worksheet.Row(1).Style.Font.Bold = true;

                //нумерация строк/столбцов начинается с индекса 1 (не 0)
                for (int i = 0; i < 5; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = 1;
                    /*worksheet.Cell(i + 2, 2).Value = string.Join(", ", phoneBrands[i].PhoneModels.Select(x => x.Title));*/
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"brands_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}