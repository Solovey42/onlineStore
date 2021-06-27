using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class AdminPageModel
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        [Range(1, 10000)]
        public double Cost { get; set; }
        public AdminPageModel(List<User> users, List<Product> products, List<Order> orders)
        {
            this.Users = users;
            this.Products = products;
            this.Orders = orders;
        }
        public AdminPageModel()
        {
        }
    }
}