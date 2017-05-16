﻿using System;
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
        protected async void Page_Load(object sender, EventArgs e)
        {

            //List<portCallMessage> list = await RestHandler.getEvents();
            //eventListBox.DataSource = list;
            //eventListBox.DataBind();

            LoadList();
            LoadEvents(sender, e);
        }


        protected void LoadList(){
            DataTable activeShips = DataBaseHandler.getActiveShips();
			List<Vessel> shipList = new List<Vessel>();

            foreach (DataRow ship in activeShips.Rows)
			{
				Vessel v = new Vessel();
                v.portCallID = ship["portCallID"].ToString();
				v.imo = ship["imoNumber"].ToString();
				v.name = ship["name"].ToString();
				shipList.Add(v);
			}
            vesselDDList.DataSource = shipList;
            vesselDDList.DataTextField = "name";
            vesselDDList.DataValueField = "portCallID";
            vesselDDList.DataBind();
        }

        protected void LoadEvents(object sender, EventArgs e){
            List<portCallMessage> list = RestHandler.getEvents();
            List<portCallMessage> eventList = list.Where(item => item.portCallId == vesselDDList.SelectedItem.Value).ToList();
            Console.WriteLine("id:" + vesselDDList.SelectedItem.Text);
			eventListBox.DataSource = eventList;
			eventListBox.DataBind();
        }
    }
}