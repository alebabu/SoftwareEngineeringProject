using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PortCDM_RestStructs;
using PortCDM_App_Code;


namespace PortCDM
{
    public partial class Timeline : System.Web.UI.Page

    {
        public string time;
        
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!(this.IsPostBack))
			{
				LoadList();
				LoadEvents(sender,e);
			}
        }
        
        protected void LoadList(){
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

        protected async void LoadEvents(object sender, EventArgs e){
            
            Console.WriteLine("loaded");
            List<portCallMessage> list = await RestHandler.getEvents(vesselDDList.SelectedItem.Value);
            List<Event> eventList = CreateEvents(list);
            List<portCallMessage> showList = GetFirstPortCalls(eventList);
            
           


            eventListBox.DataSource = list;
            eventListBox.DataBind();

        }

        protected List<portCallMessage> GetFirstPortCalls(List<Event> list)
        {
            List<portCallMessage> result = new List<portCallMessage>();
            foreach (var x in list)
            {
                result.Add(x.getPortCallList().First());
            }
            return result;
        }

        protected List<Event> CreateEvents(List<portCallMessage> list)
        {
            List<LocationState> locationList = new List<LocationState>();

            List<Event> result = new List<Event>();
        
            foreach(var x in list)
            {
                foreach(var y in result)
                {
                    portCallMessage portmsg = y.getPortCallList().First();
                    if (IsSameEvent(x,portmsg))
                    {
                        y.Add(x);
                        break;
                    }
                }
                List<portCallMessage> newList = new List<portCallMessage>();
                newList.Add(x);
                result.Add(new Event(newList));
            }
            return result;
            
        }
        
        private bool IsSameEvent(portCallMessage e1, portCallMessage e2)
        {
            if (e1.locationState != null && e2.locationState != null)
            {
                return (e1.locationState.arrivalLocation == e2.locationState.arrivalLocation &&
                    e1.locationState.departureLocation == e2.locationState.departureLocation &&
                    e1.locationState.timeType == e2.locationState.timeType);

            }
            return false;
        }
        

        public class Event
        {
            private List<portCallMessage> list;

            public Event(List<portCallMessage> list)
            {
                this.list = list;
            }

            public void Add(portCallMessage elem)
            {
                list.Add(elem);
            }

            public List<portCallMessage> getPortCallList()
            {
                return list;
            } 
            

        }

    }
}