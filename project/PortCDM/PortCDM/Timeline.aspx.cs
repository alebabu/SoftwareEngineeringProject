using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Timers;
using System.Diagnostics;
using PortCDM_RestStructs;
using PortCDM_App_Code;
using System.Reflection;



namespace PortCDM
{
    public partial class Timeline : System.Web.UI.Page

    {
        public string time;
        private string callID;
        PropertyInfo Isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        public System.Timers.Timer timer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {

                LoadList();
                LoadEvents(sender, e);
                StartTime();

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
                //TEST WITH PCMG
                foreach (var pcm in list)
                {
                    pcmg.add(pcm);
                }
                foreach (var pcm in pcmg.getGroups())
                {
                    Debug.WriteLine("PCM:");
                    foreach (var p in pcm)
                    {
                        Debug.WriteLine(p.vesselId);
                    }
                }
            }

            eventListBox.DataSource = list;
            eventListBox.DataBind();

            
        }

        protected object NiceTimeFormat(object o)
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

        
        protected object ShortenMRN(object locationMRN)
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