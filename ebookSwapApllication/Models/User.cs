using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ebookSwapApllication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string UserFullName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string UserPassword { get; set; } = String.Empty;
        public string Userphonenumber { get; set; } = String.Empty;
        public string UserCity { get; set; } = String.Empty;
        public string UserCountry { get; set; } = String.Empty;
        public string UserAdress { get; set; } = String.Empty;
        public string UserDateCreating { get; set; } = String.Empty;

        // relationships 

        public List<Book>? Books { get; set; } 



    }
}
