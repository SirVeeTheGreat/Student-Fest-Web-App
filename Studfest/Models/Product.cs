using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string ProductBrand { get; set; } = string.Empty;
        [Required]
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        public string ProductCategory { get; set; } = string.Empty;
        [Required]
        public string ProductType { get; set; } = string.Empty;
        [Required]
        public int ProductCount { get; set; } = 0;
        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public string ImageLink { get; set; }

        public bool EligibleForDelivery = false;
        [Required]
        public string Warranty { get; set; } = string.Empty;
        [Required]
        public string BoxItems { get; set; } = string.Empty;
        [Required]
     

        public DateTime DateCreated { get; set; } = DateTime.Now;
        


        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
 

        [Column("VendorId")]
        public int VendorId { get; set; }

        public ICollection<Order> Orders { get; set; }

        
    }
}
