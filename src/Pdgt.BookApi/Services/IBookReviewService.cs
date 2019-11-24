using System.Threading.Tasks;

namespace Pdgt.BookApi.Services
{
    public interface IBookReviewService
    {
        Task AddReviewAsync(string key, string review, BookRating bookRating);
    }
}
