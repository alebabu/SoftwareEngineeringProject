using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTapi_testtet
{
    public class DataObject
    {
        public string id { get; set; }
        public string portUnLocode { get; set; }
    }

       public class Class1
       {
           private const string URL = "http://192.168.56.101:8080/dmp/port_calls";
           private const string urlParameters = "?count=30";

           static void Main(string[] args)
           {
               HttpClient client = new HttpClient();
               client.BaseAddress = new Uri(URL);

               // Add an Accept header for JSON format.
               client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
               client.DefaultRequestHeaders.Add("X-PortCDM-UserId", "porter");
               client.DefaultRequestHeaders.Add("X-PortCDM-Password", "porter");
               client.DefaultRequestHeaders.Add("X-PortCDM-APIKey", "eeee");

               // List data response.
               HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
               if (response.IsSuccessStatusCode)
               {
                   // Parse the response body. Blocking!
                   var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                   foreach (DataObject d in dataObjects)
                   {
                       Console.WriteLine("{0}", d.id);
                       Console.WriteLine("{0}", d.portUnLocode);
                   }
               }
               else
               {
                   Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
               }
               Console.ReadLine();
           }
       }
}
