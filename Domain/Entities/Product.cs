using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Size { get; set; }
        public int? TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();

    }
}
