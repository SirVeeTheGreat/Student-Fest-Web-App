using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class ApprovedDeliveryTeam
    {
        public int Id { get; set; }


        [Column("DeliveryTeamId")]

        public int DeliveryTeamId { get; set; }

        [ForeignKey(nameof(DeliveryTeamId))]    
        public DeliveryTeam DeliveryTeam { get; set; }  
    }
}
