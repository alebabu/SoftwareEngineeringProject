using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PortCDM_App_Code
{
	public class RestHandler
	{
		static HttpClient client = new HttpClient();
		private const string address = "http://192.168.56.101:8080/";

		private static void prepareRestCall()
		{
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
			client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
			client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");
		}

		public static async PortCall getPortCall()
		{
			prepareRestCall();
			private const string callType = "dmp/port_calls";
		private const string callCount = "?count=30";

		client.BaseAddress = new Uri("http://www.google.com");
			//HttpResponseMessage response = client.GetAsync()

			return new PortCall();
	}
}




