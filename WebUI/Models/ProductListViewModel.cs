using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }

        [Required(ErrorMessage = "Не указано количество")]
        [Range(1, 10000, ErrorMessage = "Недопустимое значение")]
        public int? Quantity { get; set; }

        public int? SelectedProductId { get; set; }

        public ProductListViewModel(List<Product> products, int? quantity, int? selectdProductId)
        {
            this.Products = products;
            this.Quantity = quantity;
            this.SelectedProductId = selectdProductId;
        }
        public ProductListViewModel()
        {
        }
    }
}