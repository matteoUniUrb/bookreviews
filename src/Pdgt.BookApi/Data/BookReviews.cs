using System.Collections.Generic;

namespace Pdgt.BookApi.Data
{
    public class BookReviews : EntityBase
    {
        public List<BookReviewItem> BookReviewItems { get; set; }
    }
}
