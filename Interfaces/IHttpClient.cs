using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> DeleteAsync(Uri requestUri);

        Task<HttpResponseMessage> GetAsync(Uri requestUri);

        Task<byte[]> GetByteArrayAsync(Uri requestUri);

        Task<Stream> GetStreamAsync(Uri requestUri);

        Task<string> GetStringAsync(Uri requestUri);

        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);

        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}