using Pdgt.BookApi.Services;

namespace Pdgt.BookApi.Data
{
    public class BookReviewItem
    {
        public string Username { get; set; }

        public string Text { get; set; }

        public BookRating BookRating { get; set; }
    }
}