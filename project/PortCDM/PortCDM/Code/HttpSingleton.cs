using System;
using System.Net.Http;

namespace PortCDM_App_Code
{
    public sealed class HttpClientInstance : HttpClient
    {
        private static readonly HttpClientInstance instance = new HttpClientInstance();

        static HttpClientInstance(){ }

        public static HttpClient Instance
        {
            get
            {
                return Instance;
            }
        }
    }
}
