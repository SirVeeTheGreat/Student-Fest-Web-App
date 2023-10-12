using System.ComponentModel.DataAnnotations;


namespace Studfest.Models
{
    public class Login
    {
        

        [Required, Display(Name = "Email Address")]
        public string Email { get; set; }

       
        [Required, Display(Name = "Password")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;

        public bool isAdmin { get; set; } = false;

        public bool isVendor { get; set; } = false;

        public bool isDriver { get; set; } = false;
    }
}
