using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public double? UnitPrice { get; set; }
    }
}
