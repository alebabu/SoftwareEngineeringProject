using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Timers;
using System.Diagnostics;

using PortCDM.Code.Structs;
using PortCDM.Code;
using System.Reflection;
using System.Diagnostics;



namespace PortCDM
{
    public partial class Timeline : System.Web.UI.Page

    {
        List<PortLocation> portLocations;
        public string time;
        private string callID;
        PropertyInfo Isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

        public System.Timers.Timer timer;

        protected async void Page_Load(object sender, EventArgs e)

        {
            portLocations = await RestHandler.getLocations();
            if (!(this.IsPostBack))
            { 
                LoadList();
                LoadEvents(sender, e);

                //StartTime();


            }

        }

        protected void LoadList()
        {
            DataTable activeShips = DataBaseHandler.getActiveShips();
            List<Vessel> shipList = new List<Vessel>();

            foreach (DataRow ship in activeShips.Rows)
            {
                Vessel v = new Vessel();
                v.portCallId = ship["portCallID"].ToString();
                v.imo = ship["imoNumber"].ToString();
                v.name = ship["name"].ToString();
                shipList.Add(v);
            }
            vesselDDList.DataSource = shipList;
            vesselDDList.DataTextField = "name";
            vesselDDList.DataValueField = "portCallID";
            vesselDDList.DataBind();
        }

        protected async void LoadEvents(object sender, EventArgs e)
        {

            PortCallMessageGrouper pcmg = new PortCallMessageGrouper();

            callID = Request.QueryString["portCallID"];
            List<portCallMessage> list;

            if (!string.IsNullOrEmpty(callID))
            {
                list = await RestHandler.getEvents(callID);
                vesselDDList.SelectedValue = callID;
                Isreadonly.SetValue(Request.QueryString, false, null);
                Request.QueryString.Clear();
            }
            else
            {
                list = await RestHandler.getEvents(vesselDDList.SelectedItem.Value);
            }

            pcmg = new PortCallMessageGrouper(list);

            eventListBox.DataSource = pcmg.getGroups();
            eventListBox.DataBind();
            

            
        }

        protected void rptr_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            Literal boxHeader = (Literal)e.Item.FindControl("boxHeader");

            List<portCallMessage> list = (List<portCallMessage>)e.Item.DataItem;

            portCallMessage pcm = list[0];

            if (PortCallMessageGrouper.isLocationState(pcm))
            {
                if (pcm.locationState.arrivalLocation != null)
                {
                    if (pcm.locationState.arrivalLocation.to != null)
                    {
                        boxHeader.Text += "To: " + getLocationName(fixTrafficAreaBug(pcm.locationState.arrivalLocation.to.locationMRN));
                        if (pcm.locationState.arrivalLocation.from != null)
                        {
                            boxHeader.Text += "<br />";
                        }
                    }
                    if (pcm.locationState.arrivalLocation.from != null)
                    {
                        boxHeader.Text += "From: " + getLocationName(fixTrafficAreaBug(pcm.locationState.arrivalLocation.from.locationMRN)).ToString();
                    }
                }
                else if (pcm.locationState.departureLocation != null)
                {
                    if (pcm.locationState.departureLocation.to != null)
                    {
                        boxHeader.Text += "To: " + getLocationName(fixTrafficAreaBug(pcm.locationState.departureLocation.to.locationMRN));
                        if (pcm.locationState.departureLocation.from != null)
                        {
                            boxHeader.Text += "<br />";
                        }
                    }
                    if (pcm.locationState.departureLocation.from != null)
                    {
                        boxHeader.Text += "From: " + getLocationName(fixTrafficAreaBug(pcm.locationState.departureLocation.from.locationMRN));
                    }
                }
            }
            else
            {
                boxHeader.Text += FirstCharToUpper(pcm.serviceState.serviceObject.ToString()) + "<br />";
                if (pcm.serviceState.at != null)
                {
                    boxHeader.Text += "At: " + getLocationName(fixTrafficAreaBug(pcm.serviceState.at.locationMRN));
                }
                else
                {
                    boxHeader.Text += "To: " + getLocationName(fixTrafficAreaBug(pcm.serviceState.between.to.locationMRN));
                    boxHeader.Text += "<br />From: " + getLocationName(fixTrafficAreaBug(pcm.serviceState.between.from.locationMRN));
                }
            }


            Repeater timeRepeater = (Repeater)e.Item.FindControl("timeRepeater");
            Repeater boxRepeater = (Repeater)e.Item.FindControl("boxRepeater");
            timeRepeater.DataSource = e.Item.DataItem;
            timeRepeater.DataBind();
            boxRepeater.DataSource = e.Item.DataItem;
            boxRepeater.DataBind();

        }

        public static string FirstCharToUpper(string input)
        {
            input = input.ToLower() ?? "";
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1)).Replace("_", " ");
        }

        //Note(Olle): this changes the sent string to the string in the api to fetch a location
        private string fixTrafficAreaBug(string location)
        {
            return location.Replace("urn:mrn:stm:location:segot:TRAFFIC_AREA",
                "urn:mrn:stm:location:segot:TRAFFIC_AREA:segot");
        }

        private string getLocationName(string MRN)
        {
            string locationName = "";

            if (MRN.Contains("VESSEL"))
                locationName = "Vessel";
            else
                locationName = portLocations.Find(x => x.URN == MRN).name ?? "Unspecified Berth";

            return locationName;
        }

        protected object niceTimeFormat(object o)
        {
            if (o == null)
                return null;
            DateTime dateTime = (DateTime)o;

            int daysAgo = (DateTime.Now - dateTime).Days;
            daysAgo = 0;
           
            if (daysAgo < 365)
            {   // If within a year
                o = dateTime.ToString("d MMM<br />HH:mm");
            }
            else
            {   // Older date
                o = dateTime.ToString("yyyy-MM-dd<br />HH:mm");
            }
            return o;
        }
        
        protected object shortenMRN(object locationMRN)
        {        
            String s = (String)locationMRN;            
            if (s != null)
            {
                s = s.Replace("urn:mrn:stm:location:segot:", "");
                s = s.Replace("urn:mrn:legacy:user:", "");
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ':')
                    {
                       s = s.Replace(":", " at ");
                    }
                }
                return s;
            }else
            {
                return "";
            }


        }

		protected void StartTime()
		{
			Console.WriteLine("StartTime");
			timer = new System.Timers.Timer(10000);
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 10000;
			timer.Enabled = true;
		}

		protected void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine("OnTimedEvent");
			LoadEvents(source, e);
		}
    
        protected object newTime (object o)
        {
            String s = (String)o;           
            DateHandler dh = new DateHandler();
            DateTime time = dh.stringToDate(s);
             o = time.ToString("d MMM HH:mm");
            return o;
        }      
    }
}