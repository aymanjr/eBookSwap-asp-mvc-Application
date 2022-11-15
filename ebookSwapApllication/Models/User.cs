using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ebookSwapApllication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name ="UserName")]
        public string UserName { get; set; } = String.Empty;
        [Display(Name = "Full Name")]

        public string UserFullName { get; set; } = String.Empty;
        [Display(Name = "Email")]

        public string UserEmail { get; set; } = String.Empty;

        public string UserPassword { get; set; } = String.Empty;
        [Display(Name = "Phone Number")]

        public string Userphonenumber { get; set; } = String.Empty;
        [Display(Name = "City")]

        public string UserCity { get; set; } = String.Empty;
        [Display(Name = "Country")]

        public string UserCountry { get; set; } = String.Empty;
        [Display(Name = "Adress")]

        public string UserAdress { get; set; } = String.Empty;
        [Display(Name = "Date Creation")]

        public string UserDateCreating { get; set; } = String.Empty;

        // relationships 

        public List<Book>? Books { get; set; } 



    }
}
