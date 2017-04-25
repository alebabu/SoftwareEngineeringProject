using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using PortCDM_RestStructs;

namespace PortCDM_App_Code
{
	public class RestHandler
	{
		//static HttpClient client = new HttpClient();
        //static bool isReady = false;
		private const string address = "http://192.168.56.101:8080/";

		/*private static void prepareRestCall()
		{
            if (!isReady)
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");
                isReady = true;
            }
		}*/

        public static PortCall getPortCallById(string id)
        {
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");

                string callType = String.Format("/dmp/port_calls/{0}", id);

                client.BaseAddress = new Uri(address + callType);

                HttpResponseMessage response = client.GetAsync("").Result;
                PortCall portCall = new PortCall();

                if(response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<IEnumerable<PortCall>>().Result;

                    foreach (PortCall pc in result)
                        portCall = pc;

                }
                return portCall;
            }
        }

		public static List<PortCall> getPortCalls()
		{
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");

                const string callType = "dmp/port_calls/";
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
}
