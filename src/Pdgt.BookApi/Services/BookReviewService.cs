using System.Collections.Generic;
using System.Threading.Tasks;
using Pdgt.BookApi.Data;
using Pdgt.BookApi.Repositories;

namespace Pdgt.BookApi.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IRepository<BookReviews> _reviewRepository;

        public BookReviewService(IRepository<BookReviews> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task AddReviewAsync(string key, string username, string review, BookRating bookRating)
        {
            return Task.Run(() =>
            {
                var bookReviewItem = new BookReviewItem
                {
                    BookRating = bookRating,
                    Text = review,
                    Username = username
                };

                var reviews = _reviewRepository.Get(key);

                if (reviews != null)
                {
                    reviews.BookReviewItems.Add(bookReviewItem);
                    _reviewRepository.Update(reviews);
                }
                else
                {
                    reviews = new BookReviews()
                    {
                        Id = key,
                        BookReviewItems = new List<BookReviewItem>
                        {
                            bookReviewItem
                        }
                    };
                    _reviewRepository.Add(reviews);
                }

            });
        }

        public async Task<BookReviews> GetReviews(string key)
        {
            return await Task.FromResult(_reviewRepository.Get(key));
        }
    }
}