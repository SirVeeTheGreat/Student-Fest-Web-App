using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public int MobileNumber { get; set; }

        public Cart Cart { get; set; }

        public ICollection<Order> Orders { get; set; }         
    }
}
