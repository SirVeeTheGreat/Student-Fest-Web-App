using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column("OrderId")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]    
        public User User { get; set; }

        public string OrderNumber { get; } = $"#" + new Random().Next(0, 1000) + "-" + new Random().Next(0, 100);  
        
        public string OrderDetails { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<OrderItem> OrderItems { get; set; } 

    }
}
