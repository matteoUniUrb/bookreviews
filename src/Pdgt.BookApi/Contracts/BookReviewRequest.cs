using Pdgt.BookApi.Services;

namespace Pdgt.BookApi.Controllers
{
    public class BookReviewRequest
    {
        public string ReviewText { get; set; }

        public BookRating BookRating { get; set; }
    }
}