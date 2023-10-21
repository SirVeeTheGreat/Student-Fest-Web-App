using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required]

        public string VendorTitle { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage ="Your \"First Name\" must atleast be 2 charactors long or more")]
        public string VendorFirstName { get; set; } = string.Empty;
        [Required]
     
        [MinLength(2, ErrorMessage = "Your \"Last Name\" must atleast be 2 charactors long or more")]
        public string VendorLastName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string VendorEmailAddresss { get; set; } = string.Empty;
       
        [Required]
        [MinLength(13, ErrorMessage ="Invalid ID Number")]
        [MaxLength(13, ErrorMessage = "Invalid ID Number")]
        public string VendorIdNumber { get; set; }
        [Required]
        public string DriverProfileImage { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } 

        public ApprovedVendor  ApprovedVendor { get; set; }
        
        public ContactDetails ContactDetails { get; set; }

        public ICollection<Services> Services { get; set; }

        public ResidentalAddress ResidentalAddress { get; set; }
    }
}
