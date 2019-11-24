using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdgt.BookApi.Http
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient = new HttpClient();
        
        public HttpClientWrapper()
        {
            _httpClient = HttpClientFactory.Create();
        }
        
        public async Task<T> GetAsync<T>(string requestUri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                var resposeMessage = await _httpClient.SendAsync(request);
                var responseString = await resposeMessage.Content.ReadAsStringAsync();

                if (resposeMessage.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseString);
                }

                throw new Exception(responseString);
            }
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T content) 
        {
            var body = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(requestUri, httpContent);
        }
    }
}
