using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {

                LoadList();
                LoadEvents(sender, e);

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
                return s;
            }else
            {
                return "";
            }


        }



    }
}