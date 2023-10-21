using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        public User User { get; set; }  = new User();

        public string OrderNumber { set; get; }

        public List<int> ProductId { get; set; } = new List<int>();

        public DateTime DateCreated { get; set; } = DateTime.Now;
       
    }
}
