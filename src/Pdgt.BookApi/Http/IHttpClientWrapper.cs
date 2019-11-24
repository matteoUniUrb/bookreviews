using System.Net.Http;
using System.Threading.Tasks;

namespace Pdgt.BookApi.Http
{
    public interface IHttpClientWrapper
    {

        Task<string> GetAsync(string requestUri);

        Task<HttpResponseMessage> PostAsync<T>(string requestUri, T content);
    }
}