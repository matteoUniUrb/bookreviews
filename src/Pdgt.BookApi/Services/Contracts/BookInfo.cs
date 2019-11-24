using Newtonsoft.Json;

namespace Pdgt.BookApi.Services
{
    public class BookInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("number_of_pages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("languages")]
        public string[] Languages { get; set; }

        [JsonProperty("subjects")]
        public string[] Subjects { get; set; }

        [JsonProperty("authors")]
        public string[] Authors { get; set; }

        [JsonProperty("identifiers")]
        public Identifier[] Identifiers { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }
    }

    public class Identifier
    {
        [JsonProperty("isbn_10")]
        public ISBN10 Isbn10 { get; set; }
    }

    public class ISBN10
    {
        public string[] Values { get; set; }
    }
}