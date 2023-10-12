using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    [NotMapped]
    public class User
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddresss { get; set; } = string.Empty;
        public long VendorIdNumber { get; set; }
        public int MobileNumber { get; set; }
    }
}
