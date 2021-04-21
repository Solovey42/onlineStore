using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CategoryOfProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TypeOfProduct> TypeOfProducts { get; set; } = new List<TypeOfProduct>();
        public string ImagePath { get; set; }
    }
}
