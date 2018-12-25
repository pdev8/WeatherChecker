using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Interfaces;

namespace Weather.Testing.Fakes
{
    public class HttpClientFake : IHttpClient
    {
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetStreamAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStringAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public Func<HttpRequestMessage, Task<HttpResponseMessage>> SendAsyncCallBack { get; set; }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsyncCallBack?.Invoke(request);
        }
    }
}