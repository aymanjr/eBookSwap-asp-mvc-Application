using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ebookSwapApllication.Models
{
    public class LoginSignupViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "username is required")]
        public string UserName { get; set; } = String.Empty;

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is required")]

        public string UserFullName { get; set; } = String.Empty;
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]

        public string UserEmail { get; set; } = String.Empty;
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]

        public string UserPassword { get; set; } = String.Empty;
        public string UserConfirmPassword { get; set; } = String.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]

        public string Userphonenumber { get; set; } = String.Empty;
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]

        public string UserCity { get; set; } = String.Empty;
        [Display(Name = "Country")]

        public string UserCountry { get; set; } = String.Empty;
        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress is required")]

        public string UserAdress { get; set; } = String.Empty;
        [Display(Name = "Date Creation")]

        public string UserDateCreating { get; set; } = String.Empty;


        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }

    }
}
