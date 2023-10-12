using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class ContactDetails
    {
        
        public int Id { get; set; }

        public string CountryCode { get; set; } = string.Empty;

        public int MobileNumber { get; set; }

        public int AlternativeNumber { get; set; }

        public string AlternativeEmailAddress { get; set; } = string.Empty;

        [Column("VenderId")]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor  Vendors { get; set; }


        [Column("DeliveryTeamId")]
        public int DeliveryTeamId { get; set; }

        [ForeignKey(nameof(DeliveryTeamId))]
        public DeliveryTeam DeliveryTeams { get; set; }

        
    }
}


