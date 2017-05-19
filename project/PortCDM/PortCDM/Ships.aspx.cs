﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using PortCDM_RestStructs;
using PortCDM_App_Code;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace PortCDM
{
	public partial class Ships : System.Web.UI.Page
	{
		private MySqlConnection con;
		private MySqlDataAdapter sda;
		private static List<Vessel> shipList = new List<Vessel>();


		protected void Page_Load(Object sender, EventArgs e)
		{
			if (!(this.IsPostBack))
			{
				//DataBaseHandler.getAllShips().Wait();
				setDataTables();
			}

		}



		protected void commentChanged(object sender, EventArgs e)
		{
			TextBox tb = ((TextBox)sender);
			string comment = tb.Text;

			string imo = ((Literal)tb.Parent.FindControl("imo")).Text;

			DataBaseHandler.editComment(comment, imo);

			tb.Text = comment;


		}

		protected void deactivateShip(object sender, EventArgs e)
		{
			Button b = ((Button)sender);

			string imo = ((Literal)b.Parent.FindControl("imo")).Text;

			DataBaseHandler.deactivateShip(imo);

			setDataTables();

		}

		protected async void addNewShip(object sender, EventArgs e)
		{
			string addImo = Request.Form[addShipDropDown.UniqueID];
			if (shipList.Exists(obj => obj.imo == addImo))
			{
				DataBaseHandler.activateShip(addImo);
			}
			else
			{
				string result = await RestHandler.createPortCall(addImo);
				string[] resultlist = result.Split('"');
				string portCallId = resultlist[3];

				Vessel v = await RestHandler.getVesselByImo(addImo);

				DataBaseHandler.addShip(v, portCallId);
			}
			setDataTables();
		}

		private void setDataTables()
		{
			DataTable activeShipsDt = new DataTable();
			activeShipsDt = DataBaseHandler.getActiveShips();
			shipRepeater.DataSource = activeShipsDt;
			shipRepeater.DataBind();

			shipList.Clear();
			DataTable inActiveShipsDT = DataBaseHandler.getInActiveShips();
			foreach (DataRow ship in inActiveShipsDT.Rows)
			{
				Vessel v = new Vessel();
				v.imo = ship["imoNumber"].ToString();
				v.name = ship["name"].ToString();
				shipList.Add(v);
			}
			addShipDropDown.DataSource = shipList;
			addShipDropDown.DataTextField = "imo";
			addShipDropDown.DataValueField = "imo";

			addShipDropDown.DataBind();
		}
	}
}