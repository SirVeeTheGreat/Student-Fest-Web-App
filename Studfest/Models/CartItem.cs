using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductQuanint { get; set; }

        [Column("CartId")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }
    }
}
