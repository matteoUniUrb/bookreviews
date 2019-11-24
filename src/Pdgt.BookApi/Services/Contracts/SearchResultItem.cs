using Newtonsoft.Json;

namespace Pdgt.BookApi.Services.Contracts
{
    public class SearchResultItem
    {
        [JsonProperty("edition_key")]
        public string[] Keys { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author_name")]
        public string[] AuthorNames { get; set; }

        [JsonProperty("publish_year")]
        public string[] PublishYears { get; set; }

        [JsonProperty("author_key")]
        public string[] AuthorKeys { get; set; }
    }
}