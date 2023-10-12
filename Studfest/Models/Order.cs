using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Order
    {
        public int Id { get; set; }


        public string OrderNumber { get; } = $"#" + new Random().Next(0, 1000) + "-" + new Random().Next(0, 100);

        public int PickUpVerificationCode { get; } = new Random().Next(0 , 10000);

        public int DeliveryUpVerificationCode { get; } = new Random().Next(0, 10000);

        [Column("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime EstimatedDeliveryTime { get; set; }

        [Column("DeliveryTeamId")]
        public int DeliveryTeamId { get; set; } 

        [ForeignKey(nameof(DeliveryTeamId))] 
        public DeliveryTeam DeliveryTeam { get; set; } = null!;

        [Column("DeliverInfoId")]
        public int DeliverInfoId { get; set; }

        [ForeignKey(nameof(DeliverInfoId))] 
        public DeliveryInformation DeliveryInformation { get; set; }
    }
}
