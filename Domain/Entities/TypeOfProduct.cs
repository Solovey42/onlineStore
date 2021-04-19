using System.Collections.Generic;

namespace Domain.Entities
{
    public class TypeOfProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public TypeOfProduct()
        {
            Products = new List<Product>();
        }
        public int? CategoryOfProductId { get; set; }
        public CategoryOfProduct CategoryOfProduct { get; set; }
    }
}
