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

            eventListBox.DataSource = list;
            eventListBox.DataBind();

        }

    }
}