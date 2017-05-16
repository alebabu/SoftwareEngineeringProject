using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PortCDM_Filter;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;
using System.Text;



namespace PortCDM_App_Code
{
    public class QueueHandler
    {
	
		//Creates a Queue with a list of Filters
		public static async Task<String> createFilteredQueue(List<Filter> filters)
		{

			PrepareRestCall.postXML();
			string jsonFilter = "[\n";

			for (int i = 0; i < filters.Count; i++)
			{
				if (i != filters.Count - 1)
				{
					jsonFilter += (filters[i].toJson() + ",\n");
				}
				else
				{
					jsonFilter += (filters[i].toJson());
				}
			}
			jsonFilter += "\n]";

			Console.WriteLine("Filters in Json format:\n" + jsonFilter);
			var response = await PrepareRestCall.HttpClientInstance.PostAsync("mb/mqs", new StringContent((jsonFilter), Encoding.UTF8, "application/json"));
			string result = response.Content.ReadAsStringAsync().Result;
			response.EnsureSuccessStatusCode();
			return result;
		}

        public static async Task<String> createFilteredQueue(List<Filter> filters, string date)
        {
            PrepareRestCall.postXML();
            string jsonFilter = "[\n";

            for (int i = 0; i < filters.Count; i++)
            {
                if (i != filters.Count - 1)
                {
                    jsonFilter += (filters[i].toJson() + ",\n");
                }
                else
                {
                    jsonFilter += (filters[i].toJson());
                }
            }
            jsonFilter += "\n]";

            Console.WriteLine("Filters in Json format:\n" + jsonFilter);
            var response = await PrepareRestCall.HttpClientInstance.PostAsync("mb/mqs?fromTime=" + date, new StringContent((jsonFilter), Encoding.UTF8, "application/json"));
            string result = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            return result;
        }

        public static async Task<List<portCallMessage>> pollQueue(string queueId)
		{
			PrepareRestCall.getXML();

			List<portCallMessage> pcm = null;

			var response = await PrepareRestCall.HttpClientInstance.GetAsync(String.Format("mb/mqs/{0}", queueId));
			if (response.IsSuccessStatusCode)
			{
				var responseData = await response.Content.ReadAsStringAsync();

				XmlSerializer ser = new XmlSerializer(typeof(portCallMessages));
				StringReader sr = new StringReader(responseData);
				portCallMessages pcms = (portCallMessages)ser.Deserialize(sr);

				pcm = pcms.pcms;
			}
			return pcm;
		}
    }
}
