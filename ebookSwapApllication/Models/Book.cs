using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ebookSwapApllication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; } = string.Empty;

        public string? BookISBN13 { get; set; }
        public string BookLanguage { get; set; } = string.Empty;
        public string BookNumPages { get; set; } = string.Empty;
        public string BookPublicationDate { get; set; } = string.Empty;
        public string BookPublisherID { get; set; } = string.Empty;
        public string BookAuthor { get; set; } = string.Empty;
        public string BookCategory { get; set; } = string.Empty;

        public string? BookDescription { get; set; }
        public string BookCondition { get; set; } = string.Empty;
        public string BookNotes { get; set; } = string.Empty;
        public string BookImagePath { get; set; } = string.Empty;
        public string BookFilePath { get; set; } = string.Empty;

        //relationships 
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
