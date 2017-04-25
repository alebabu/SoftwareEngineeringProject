using System;
using System.Runtime;
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

		private static List<PortCall> getPortCalls()
		{
			prepareRestCall();
			const string callType  = "dmp/port_calls/";
			const string callCount = "?count=30";
			client.BaseAddress = new Uri(address + callType);

			// List data response.
			HttpResponseMessage response = client.GetAsync(callCount).Result;  // Blocking call!
			List<PortCall> portCalls = new List<PortCall>();

			if (response.IsSuccessStatusCode)
			{
				//Parse
				var result = response.Content.ReadAsAsync<IEnumerable<PortCall>>().Result;

				foreach (PortCall pc in result)
				{
					portCalls.Add(pc);
				}
			}
			return portCalls;
		}


	}
}
