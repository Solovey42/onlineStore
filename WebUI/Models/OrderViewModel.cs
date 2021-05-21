using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class OrderViewModel
    {
        public Cart Cart { get; set; }
        public int Price { get; set; }
    }
}
