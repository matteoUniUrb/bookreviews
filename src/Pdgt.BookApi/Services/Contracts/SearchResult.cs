using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pdgt.BookApi.Services.Contracts
{
    public  class SearchResult
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("num_found")]
        public int SearchResultCount{ get; set; }

        [JsonProperty("docs")]
        public IEnumerable<SearchResultItem> Items { get; set; }
    }
}