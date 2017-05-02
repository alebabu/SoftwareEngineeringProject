using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Runtime;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PortCDM_RestStructs;
using Formatting = System.Xml.Formatting;

namespace RestTestTest
{
    public class PortCall
    {
        public string id { get; set; }
        public string arrivalDate { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();
        private const string baseURL = "http://192.168.1.115:8080/";

        private static bool isPrepared = false;

        private static void prepareGETJson()
        {
            if (!isPrepared)
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");
            isPrepared = true;
        }

        private static void prepareGETXML()
        {
            if (!isPrepared)
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
                client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");
            isPrepared = true;
        }

        private static void preparePOSTXML()
        {
            if (!isPrepared)
                client.BaseAddress = new Uri(baseURL);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
            client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
            client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");
            isPrepared = true;
        }

        private static string toXML(portCallMessage pcm)
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

        static async Task<List<PortCall>> getPortCalls()
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

        static async Task<Uri> createPCM(portCallMessage pcm)
        {
            preparePOSTXML();

            var response = await client.PostAsync("amss/state_update", new StringContent(toXML(pcm), Encoding.UTF8, "application/xml"));
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static async Task<PortCall> getPortCallById(string id)
        {
            prepareGETJson();

            PortCall pc = null;

            var response = await client.GetAsync(String.Format("dmp/port_calls/{0}", id));
            if(response.IsSuccessStatusCode)
                pc = await response.Content.ReadAsAsync<PortCall>();

            return pc;
        }

        static async Task<List<portCallMessage>> pollQueue(string queueId)
        {
            prepareGETJson();

            List<portCallMessage> pcm = null;

            var response = await client.GetAsync(String.Format("mb/mqs/{0}", queueId));
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseData);
                pcm = JsonConvert.DeserializeObject<IEnumerable<portCallMessage>>(responseData).ToList();
            }

            return pcm;
        }


        static async Task run()
        {
            List<PortCall> test = await getPortCalls();
            PortCall b = await getPortCallById(test[0].id);/*
            if(b != null)
                Console.WriteLine(b.id);
            else
            {
                Console.WriteLine("Vafan");
            }*/

            List<portCallMessage> pcmList = await pollQueue("88015055-65d1-4206-bec0-edb9511b6c1f");
            //FETT FEL MED DATETIME PARSENING
            portCallMessage pcml = pcmList[0];
            LocationState ls = (LocationState) pcml.locationState;
            LocationStateArrivalLocation arrivalLocation = (LocationStateArrivalLocation) ls.arrivalLocation;
            pcml.messageId = "2342r345gadgfawfafe45grstsd";
            Console.WriteLine(toXML(pcml));
            await createPCM(pcml);
            //pcmList = await pollQueue("88015055-65d1-4206-bec0-edb9511b6c1f");
            Console.WriteLine(pcml.portCallId);
        }

        static void Main(string[] args)
        {
            run().Wait();
        }
    }
}
