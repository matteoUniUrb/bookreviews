using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pdgt.BookApi.Configurations;
using Pdgt.BookApi.Http;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IOptions<OpenLibraryConfig> _config;

        public OpenLibraryService(IHttpClientWrapper httpClientWrapper, IOptions<OpenLibraryConfig> config)
        {
            _httpClientWrapper = httpClientWrapper;
            _config = config;
        }

        public async Task<SearchResult> GetSearchResultAsync(string text)
        {
            var endpoint = string.Format(_config.Value.SearchEndpointFormat, _config.Value.Uri, text);
            var responseString = await _httpClientWrapper.GetAsync(endpoint);
            return JsonConvert.DeserializeObject<SearchResult>(responseString);
        }

        public async Task<BookInfo> GetBookInfoAsync(string key)
        {
            var endpoint = string.Format(_config.Value.BookDetailsEndpointFormat, _config.Value.Uri, key);
            var stringBookInfo =  await _httpClientWrapper.GetAsync(endpoint);
            //the book item is wrapped in an item in dynamic format {"OLID:{id}": { json content }
            var jsonString = ((JObject)JsonConvert.DeserializeObject(stringBookInfo)).First.First.ToString();
            return JsonConvert.DeserializeObject<BookInfo>(jsonString);
        }
    }
}