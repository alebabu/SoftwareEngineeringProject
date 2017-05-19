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
        static string toXML(portCallMessage pcm)
        {
            pcm.namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[]
            {
                new XmlQualifiedName(string.Empty, "urn:mrn:stm:schema:port-call-message:0.6")
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
            PrepareRestCall.postXML();

            var response = await PrepareRestCall.HttpClientInstance.PostAsync("mb/mss", new StringContent(toXML(pcm), Encoding.UTF8, "application/xml"));

            string result = response.ReasonPhrase + " - " + response.Content.ReadAsStringAsync().Result;

            return result;
        }

        public static async Task<List<PortLocation>> getLocations()
        {
            List<PortLocation> locations = new List<PortLocation>();
            using (HttpClient tempClient = new HttpClient())
            {
                tempClient.BaseAddress = new Uri("http://dev.portcdm.eu:8080");
                tempClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                tempClient.DefaultRequestHeaders.Add("X-PortCDM-UserId", "viktoria");
                tempClient.DefaultRequestHeaders.Add("X-PortCDM-Password", "vik123");
                tempClient.DefaultRequestHeaders.Add("X-PortCDM-APIKey", PrepareRestCall.apiKey);    

                var response = await tempClient.GetAsync("/location-registry/locations/?requestType=ALL");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsAsync<IEnumerable<PortLocation>>();
                    locations = responseData.ToList();
                }
            }
            return locations;
        }

        public static async Task<PortCall> getPortCallById(string id)
        {
            PrepareRestCall.getJson();

            PortCall pc = new PortCall();

            var response = await PrepareRestCall.HttpClientInstance.GetAsync(String.Format("dmp/port_calls/{0}", id));
            if (response.IsSuccessStatusCode)
                pc = await response.Content.ReadAsAsync<PortCall>();

            return pc;
        }

        public static async Task<List<PortCall>> getPortCalls()
        {
            PrepareRestCall.getJson();

            List<PortCall> pc = null;

            var response = await PrepareRestCall.HttpClientInstance.GetAsync("dmp/port_calls");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsAsync<IEnumerable<PortCall>>();
                pc = responseData.ToList();
            }
            return pc;

        }

        public static async Task<string> getPortCallId(string imo, string plannedArrival)
        {
            PrepareRestCall.getText();

            string result = null;

            var response = await PrepareRestCall.HttpClientInstance.GetAsync(String.Format("dmp/port_call_finder/{0}/{1}", imo, plannedArrival));

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public static Task<string> getPortCallId(string imo, DateTime plannedArrival)
        {
            return getPortCallId(imo, plannedArrival.ToString());
        }



        public async static Task<List<portCallMessage>> getEvents(string callID)
        {
            string date = "2000-04-03T14:00:34Z";
            List<Filter> filters = new List<Filter>();
            Filter filter1 = new Filter(FilterType.PORT_CALL, callID);
            filters.Add(filter1);

            string q = await QueueHandler.createFilteredQueue(filters, date);

            var list = await QueueHandler.pollQueue(q);
            System.Diagnostics.Debug.WriteLine("listan: " + list);
            return list;

        }

		public static async Task<string> createPortCall(string imo)
 		{
 			PrepareRestCall.postXML();
 
 			string vesselId = "urn:mrn:stm:vessel:IMO:" + imo;
 
 			string body = "{\"vesselId\": \"" + vesselId + "\"}";
 
 			var response = await PrepareRestCall.HttpClientInstance.PostAsync("pcr/port_call", new StringContent(body, Encoding.UTF8, "application/json"));
 
 			string result = response.ReasonPhrase + " - " + response.Content.ReadAsStringAsync().Result;
 			string responseContent = response.Content.ReadAsStringAsync().Result;
 
 			string[] resultlist = responseContent.Split('"');
 			string portCallId = resultlist[3];
 			return result;   
 		}


 		public static async Task<Vessel> getVesselByImo(string imo)
 		{
 			PrepareRestCall.getJson();
			string vesselId = "urn:mrn:stm:vessel:IMO:" + imo;
 
 			Vessel v = new Vessel();
 
 			var response = await PrepareRestCall.HttpClientInstance.GetAsync(String.Format("vr/vessel/{0}", vesselId));
 			if (response.IsSuccessStatusCode)
 				v = await response.Content.ReadAsAsync<Vessel>();
 
 			return v;   
 		}
    }
}

