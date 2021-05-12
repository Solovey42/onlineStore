using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductCartModel
    {
        public IEnumerable<CartDetail> cartDetails { get; set; }
        public string ReturnUrl { get; set; }
        public ProductCartModel(IEnumerable<CartDetail> cartDetails)
        {
            this.cartDetails = cartDetails;
        }
    }
}
