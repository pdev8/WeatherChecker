using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Interfaces;

namespace Weather.Services
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient client;

        public HttpClientWrapper(HttpMessageHandler httpMessageHandler)
        {
            EnsureSecurityProtocol();
            this.client = new HttpClient(httpMessageHandler);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            EnsureSecurityProtocol();
            return this.client.DeleteAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            EnsureSecurityProtocol();
            return this.client.GetAsync(requestUri);
        }

        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            EnsureSecurityProtocol();
            return this.client.GetByteArrayAsync(requestUri);
        }

        public Task<Stream> GetStreamAsync(Uri requestUri)
        {
            EnsureSecurityProtocol();
            return this.client.GetStreamAsync(requestUri);
        }

        public Task<string> GetStringAsync(Uri requestUri)
        {
            EnsureSecurityProtocol();
            return this.client.GetStringAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            EnsureSecurityProtocol();
            return this.client.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            EnsureSecurityProtocol();
            return this.client.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            EnsureSecurityProtocol();
            return this.client.SendAsync(request);
        }

        private static void EnsureSecurityProtocol()
        {
            // Note: GP requires SecurityProtocolType.Tls and DLSWorldWideDispatcher potentially requires SSL3
            if (ServicePointManager.SecurityProtocol != (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            }
        }
    }
}