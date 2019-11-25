using System.Threading.Tasks;
using Pdgt.BookApi.Data;

namespace Pdgt.BookApi.Services
{
    public interface IBookReviewService
    {
        Task AddReviewAsync(string key, string username, string review, BookRating bookRating);

        Task<BookReviews> GetReviews(string key);
    }
}
