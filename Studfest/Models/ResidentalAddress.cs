using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class ResidentalAddress
    {
        public int Id { get; set; } 

        public string HouseNumber { get; set; } = string.Empty;

        public string StreetName { get; set; } = string.Empty;

        public string suburb { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        [Column("VendorId")]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
