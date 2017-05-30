using System;
using System.Net.Http;

namespace PortCDM.Code
{
    public sealed class HttpClientInstance
    {
        private static readonly HttpClient Instance = new HttpClient();

        public static HttpClient instance
        {
            get
            {
                return Instance;
            }
        }
    }
}
