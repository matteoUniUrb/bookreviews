using Microsoft.Extensions.Options;
using Pdgt.BookApi.Configurations;
using Pdgt.BookApi.Data;

namespace Pdgt.BookApi.Repositories
{

    public class ReviewsRepository : RepositoryBase<BookReviews>
    {
        public ReviewsRepository(IOptions<ReviewsRepositoryConfig> config) : base(config.Value.Filename)
        {
        }
    }
}