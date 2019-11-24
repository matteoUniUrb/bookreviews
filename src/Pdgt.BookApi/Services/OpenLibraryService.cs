using System.Threading.Tasks;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        public Task<SearchResult> GetSearchResultAsync(string text)
        {
            return Task.FromResult(default(SearchResult));
        }

        public Task<BookInfo> GetBookInfoAsync(string key)
        {
            return Task.FromResult(default(BookInfo));
        }
    }
}