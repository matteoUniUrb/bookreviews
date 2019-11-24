using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Pdgt.BookApi.Configurations;
using Pdgt.BookApi.Http;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        private const string SearchEndpointFormat = "{0}/search.json?q={1}";
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IOptions<OpenLibraryConfig> _config;

        public OpenLibraryService(IHttpClientWrapper httpClientWrapper, IOptions<OpenLibraryConfig> config)
        {
            _httpClientWrapper = httpClientWrapper;
            _config = config;
        }

        public async Task<SearchResult> GetSearchResultAsync(string text)
        {
            var endpoint = string.Format(SearchEndpointFormat, _config.Value.Uri, text);
            return await _httpClientWrapper.GetAsync<SearchResult>(endpoint);
        }

        public Task<BookInfo> GetBookInfoAsync(string key)
        {
            return Task.FromResult(default(BookInfo));
        }
    }
}