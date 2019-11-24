using System.Threading.Tasks;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        public Task<SearchResult> GetSearchResultAsync(string text)
        {
            throw new System.NotImplementedException();
        }

        public Task<BookInfo> GetBookInfoAsync(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}