using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Size { get; set; }
        public string Unit { get; set; }
        public int? TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
        public List<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
