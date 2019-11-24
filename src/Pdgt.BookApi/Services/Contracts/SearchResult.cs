using System.Collections.Generic;

namespace Pdgt.BookApi.Services.Contracts
{
    public  class SearchResult
    {
        public int Start { get; set; }

        public int SearchResultCount{ get; set; }

        public IEnumerable<SearchResultItem> Items { get; set; }
    }
}