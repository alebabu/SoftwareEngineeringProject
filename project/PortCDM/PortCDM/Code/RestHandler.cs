
﻿#define SECONDARYIP
//NOTE(Olle): comment out the above to use the standard ip (192.168.56.101:8080)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using PortCDM_RestStructs;
using PortCDM_Filter;
using System.Xml.Serialization;
using System.Xml;

namespace PortCDM_App_Code
{
    public class RestHandler
	{
        private static HttpClient client = new HttpClient();
#if SECONDARYIP
        private const string baseURL = "http://192.168.1.115:8080";
#else
        private const string baseURL = "http://192.168.56.101:8080/";
#endif

        private const string apiUserName = "porter";
	    private const string apiPassword = "porter";
	    private const string apiKey = "eeee";

        private static bool isPrepared = false;

        static void prepareGETJson()
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

        static void prepareGETText()
        {
            if(!isPrepared)
                client.BaseAddress = new Uri(baseURL);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
            client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
            client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
            isPrepared = true;
        }

        static void prepareGETXML()
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

        static void preparePOSTXML()
        {
            if (!isPrepared)
                client.BaseAddress = new Uri(baseURL);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-PortCDM-UserId", apiUserName);
            client.DefaultRequestHeaders.Add("X-PortCDM-Password", apiPassword);
            client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", apiKey);
            isPrepared = true;
        }

        static string toXML(portCallMessage pcm)
        {
            pcm.namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[]
            {
                new XmlQualifiedName(string.Empty, "urn:x-mrn:stm:schema:port-call-message:0.0.16")
            });
            XmlSerializer xs = new XmlSerializer(typeof(portCallMessage), new XmlRootAttribute("portCallMessage") { Namespace = "urn:x-mrn:stm:schema:port-call-message:0.0.16" });
            StringWriter sw = new StringWriter();

            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Encoding = Encoding.UTF8;
            xws.Indent = true;

            XmlWriter xtw = XmlWriter.Create(sw, xws);

            xs.Serialize(xtw, pcm, pcm.namespaces);

            return sw.ToString();
        }

        public static async Task<string> createPCM(portCallMessage pcm)
        {
            preparePOSTXML();

            var response = await client.PostAsync("amss/state_update", new StringContent(toXML(pcm), Encoding.UTF8, "application/xml"));

            string result = response.ReasonPhrase + " - " + response.Content.ReadAsStringAsync().Result;

            return result;
        }

        public static async Task<PortCall> getPortCallById(string id)
        {
            prepareGETJson();

            PortCall pc = new PortCall();

            var response = await client.GetAsync(String.Format("dmp/port_calls/{0}", id));
            if (response.IsSuccessStatusCode)
                pc = await response.Content.ReadAsAsync<PortCall>();

            return pc;
        }

        public static async Task<List<PortCall>> getPortCalls()
        {
            prepareGETJson();

            List<PortCall> pc = null;

            var response = await client.GetAsync("dmp/port_calls");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsAsync<IEnumerable<PortCall>>();
                pc = responseData.ToList();
            }
            return pc;
        }

		//Creates a Queue with a list of Filters
		public static async Task<String> createFilteredQueue(List<Filter> filters)
		{
			preparePOSTXML();
			string jsonFilter = "[\n";

			for (int i = 0; i < filters.Count(); i++)
			{
				if (i != filters.Count() - 1)
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
			var response = await client.PostAsync("mb/mqs", new StringContent((jsonFilter), Encoding.UTF8, "application/json"));
			string result = response.Content.ReadAsStringAsync().Result;
			response.EnsureSuccessStatusCode();
			return result;
		}

        public static async Task<List<portCallMessage>> pollQueue(string queueId)
        {
            prepareGETXML();

            List<portCallMessage> pcm = null;

            var response = await client.GetAsync(String.Format("mb/mqs/{0}", queueId));
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

        public static async Task<string> getPortCallId(string imo, string plannedArrival)
        {
            prepareGETText();

            string result = null;

            var response = await client.GetAsync(String.Format("dmp/port_call_finder/{0}/{1}", imo, plannedArrival));

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public static Task<string> getPortCallId(string imo, DateTime plannedArrival)
        {
            return getPortCallId(imo, plannedArrival.ToString());
        }
      
              
      
      public static List<portCallMessage> getEvents()
        {
            

            
            List<portCallMessage> list = new List<portCallMessage>();
            portCallMessage test = new portCallMessage();
            test.locationState = new LocationState();
            test.locationState.timeType = TimeType.ESTIMATED;
            test.vesselId = "bajs69";
            
            test.locationState.time = "13:00";
            test.serviceState = new ServiceState();
            test.serviceState.at = new Location();
            test.serviceState.serviceObject = ServiceObject.ANCHORING;
            
            test.serviceState.at.name = "Port of Gothenburg";
            portCallMessage test2 = new portCallMessage();
            test2.locationState = new LocationState();
            test2.serviceState = new ServiceState();
            test2.serviceState.at = new Location();
            test2.locationState.timeType = TimeType.ESTIMATED;
            test2.vesselId = "bajs70";
            test2.locationState.time = "14:00";
            test2.serviceState.serviceObject = ServiceObject.GANGWAY;
            test2.serviceState.at.name = "China";
            list.Add(test);
            list.Add(test2);
            return list;
        }
	}
}

