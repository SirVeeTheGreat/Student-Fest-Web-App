using System.ComponentModel.DataAnnotations;

namespace Studfest.Models
  {
    public class SignUp
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }


        [Required, Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required, Display(Name = "Password")]
        public string Password { get; set; }

        [Required, Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password must match the your password")]
        public string ConfirmPassword { get; set; }



    }
}
