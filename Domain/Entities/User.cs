using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactPhone { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public Cart Cart { get; set; } 
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
