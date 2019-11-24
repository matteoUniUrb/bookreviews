using System.ComponentModel.DataAnnotations;
using Pdgt.BookApi.Services;

namespace Pdgt.BookApi.Contracts
{
    public class BookReviewRequest
    {
        /// <summary>
        /// Il testo della recensione
        /// </summary>
        [Required]
        public string ReviewText { get; set; }

        /// <summary>
        /// Il rating della recensione (da 1 a 5)
        /// </summary>
        [Required]
        public BookRating BookRating { get; set; }
    }
}