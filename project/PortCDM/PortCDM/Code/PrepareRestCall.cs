using System;
using System.Net.Http.Headers;

namespace PortCDM_App_Code
{
    public static class PrepareRestCall
    {
	    public static HttpClientInstance HttpClientInstance = new HttpClientInstance();

#if SECONDARYIP
        private const string baseURL = "http://192.168.1.115:8080";
#else
		private const string baseURL = "http://192.168.56.101:8080/";
#endif

		private const string apiUserName = "porter";
		private const string apiPassword = "porter";
		private const string apiKey = "eeee";

		private static bool isPrepared = false;

		public static void getJson()
		{
			if (!isPrepared)
				HttpClientInstance.BaseAddress = new Uri(baseURL);

			HttpClientInstance.DefaultRequestHeaders.Clear();
			HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void getText()
		{
			if (!isPrepared)
				HttpClientInstance.BaseAddress = new Uri(baseURL);

			HttpClientInstance.DefaultRequestHeaders.Clear();
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void getXML()
		{
			if (!isPrepared)
				HttpClientInstance.BaseAddress = new Uri(baseURL);

			HttpClientInstance.DefaultRequestHeaders.Clear();
			HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}

		public static void postXML()
		{
			if (!isPrepared)
				HttpClientInstance.BaseAddress = new Uri(baseURL);

			HttpClientInstance.DefaultRequestHeaders.Clear();
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
			HttpClientInstance.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
			isPrepared = true;
		}
    }
}
