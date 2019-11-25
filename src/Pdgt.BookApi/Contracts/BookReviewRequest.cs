using System.ComponentModel.DataAnnotations;
using Pdgt.BookApi.Services;

namespace Pdgt.BookApi.Contracts
{
    public class BookReviewRequest
    {
        /// <summary>
        /// Username del recensore
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Il testo della recensione
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Il rating della recensione (da 1 a 5)
        /// </summary>
        [Required]
        public BookRating Rating { get; set; }
    }
}