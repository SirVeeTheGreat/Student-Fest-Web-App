using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Column("OrderId")]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
