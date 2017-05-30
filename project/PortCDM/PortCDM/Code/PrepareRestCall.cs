using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PortCDM.Code
{
    public static class PrepareRestCall
    {
        private static readonly HttpClient client = HttpClientInstance.instance;

		private const string baseURL = "http://sandbox-5.portcdm.eu:8080/";


		private const string apiUserName = "test23";
		private const string apiPassword = "test123";
		public const string apiKey = "eeee";

		private static bool isPrepared = false;

		public static void getJson()
		{
			if (!isPrepared)
				client.BaseAddress = new Uri(baseURL);

			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void getText()
		{
			if (!isPrepared)
				client.BaseAddress = new Uri(baseURL);

			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void getXML()
		{
			if (!isPrepared)
				client.BaseAddress = new Uri(baseURL);

			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
			client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void postXML()
		{
			if (!isPrepared)
				client.BaseAddress = new Uri(baseURL);

			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}
    }
}
