using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ebookSwapApllication.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }




        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }

    }
}
