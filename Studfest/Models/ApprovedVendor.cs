using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class ApprovedVendor
    {
        public int Id { get; set; }

        [Column("VendorId")]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }

        public bool IsApproved { get; set; } = false;  
    }
}
