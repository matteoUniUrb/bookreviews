using System.Threading.Tasks;

namespace Pdgt.BookApi.Services
{
    public class BookReviewService : IBookReviewService
    {
        public Task AddReviewAsync(string key, string review, BookRating bookRating)
        {
            return Task.CompletedTask;
        }
    }
}