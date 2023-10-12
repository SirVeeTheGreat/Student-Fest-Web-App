using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class ServiceProvidersDocuments
    {
        public int Id { get; set; } 

        public string DocumentType { get; set; }    

        public string DocumentPath { get; set; }

        public string DocumentName { get; set; }

        public bool IsUploaded { get; set; } = false;    

        public ICollection<Vendor> Vendors { get; set; }

        public ICollection<DeliveryTeam> DeliveryTeams { get; set; }


        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }


        [Column("VendorId")]
        public int VendorId { get; set; }
    }
}
