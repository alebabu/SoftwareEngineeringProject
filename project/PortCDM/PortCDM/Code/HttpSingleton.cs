using System;
using System.Net.Http;

namespace PortCDM.Code
{
    public sealed class HttpClientInstance : HttpClient
    {
        private static readonly HttpClientInstance instance = new HttpClientInstance();

        public static HttpClient Instance
        {
            get
            {
                return Instance;
            }
        }
    }
}
