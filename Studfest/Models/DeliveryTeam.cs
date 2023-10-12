using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class DeliveryTeam
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Your \"First Name\" must atleast be 2 charactors long or more")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Your \"Last Name\" must atleast be 2 charactors long or more")]

        public string LastName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;

        public ICollection<ContactDetails> ContactDetails { get; set; } = null!;
          
        public int VehicleRegistrationNumber { get; set; }
        [Required]
      
        public int DriversLicence { get; set; }
        [Required]
        public string DriverProfileImage { get; set; }
        [Required]
        public string VehileImage { get; set; }

        public ICollection<ApprovedDeliveryTeam> ApprovedDeliveryTeams { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;
        public string ClaimType { get; } = "VENDOR";

    }
}
