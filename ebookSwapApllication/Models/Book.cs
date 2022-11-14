using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ebookSwapApllication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; } = String.Empty;
        public string BookISBN13 { get; set; } = String.Empty;
        public string BookLanguage { get; set; } = String.Empty;
        public string BookNumPages { get; set; } = String.Empty;
        public DateTime BookPublicationDate { get; set; }
        public string BookPublisherID { get; set; } = String.Empty;
        public string BookAuthor { get; set; } = String.Empty;
        public string BookCategory { get; set; } = String.Empty;
        public string BookDescription { get; set; } = String.Empty;
        public string BookCondition { get; set; } = String.Empty;
        public string BookNotes { get; set; } = String.Empty;
        public string BookImagePath { get; set; } = String.Empty;


        //relationships 

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public User? User { get; set; }  
    }
}
