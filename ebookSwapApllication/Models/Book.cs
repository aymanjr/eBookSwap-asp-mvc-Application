using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ebookSwapApllication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; } = String.Empty;

        public string? BookISBN13 { get; set; } 
        public string BookLanguage { get; set; } 
        public string BookNumPages { get; set; } 
        public string BookPublicationDate { get; set; } 
        public string BookPublisherID { get; set; }
        public string BookAuthor { get; set; } 
        public string BookCategory { get; set; } = String.Empty;
        [NotMapped]
        public SelectList? BookCategoryList { get; set; }
        public string? BookDescription { get; set; } 
        public string BookCondition { get; set; } = String.Empty;
        public string BookNotes { get; set; } = String.Empty;
        public string BookImagePath { get; set; } = String.Empty;

        //relationships 

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public User? User { get; set; }
    }
}
