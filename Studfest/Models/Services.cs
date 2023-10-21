using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Services
    {
        public int Id { get; set; }    

        public string ServiceDescription { get; set; } = string.Empty;

        public string ServiceName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } 

        [Column("VendorId")]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]  
        public Vendor Vendor { get; set; }
    }
}
