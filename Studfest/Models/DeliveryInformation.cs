using System.ComponentModel.DataAnnotations;

namespace Studfest.Models
{
    public class DeliveryInformation
    {
        public int Id { get; set; }

        [Required]
        public string DeliveryHouseNumber { get; set; } = string.Empty;
        [Required]
        public string DeliveryStreetName { get; set; } = string.Empty;
        [Required]
        public string Deliverysuburb { get; set; } = string.Empty;
        [Required]
        public string DeliveryCity { get; set; } = string.Empty;
        [Required]

        public string DeliveryPostalCode { get; set; } = string.Empty;
        [Required]
        public string DeliveryCountry { get; set; } = string.Empty;
        [Required]
        public int receiptContactNumber { get; set; } 

        public ICollection<Order> Orders { get; set; }  

    }
}
