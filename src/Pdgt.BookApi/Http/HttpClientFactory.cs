using System;
using System.Net.Http;

namespace Pdgt.BookApi.Http
{
    public static class HttpClientFactory
    {
        private static HttpClient _httpClient;

        public static HttpClient Create()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };

                _httpClient.DefaultRequestHeaders.Connection.Clear();
                _httpClient.DefaultRequestHeaders.ConnectionClose = true;
            }

            return _httpClient;
        }
    }
}