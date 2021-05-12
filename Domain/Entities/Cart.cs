using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartDetail> CartDetail { get; set; } = new List<CartDetail>();
        public decimal ComputeTotalValue()
        {
            return (decimal)CartDetail.Sum(e => e.Product.Cost * e.Quantity);

        }
    }
}
