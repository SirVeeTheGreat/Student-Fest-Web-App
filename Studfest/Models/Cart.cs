using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<CartItem> CartItem { get; set; }

    }
}
