using System;
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
		public MySqlConnection con;
		public MySqlDataAdapter sda;


		protected void Page_Load(Object sender, EventArgs e)
		{
			if (!(this.IsPostBack))
			{
				DataBaseHandler.getAllShips().Wait();
				DataTable activeShipsDt = new DataTable();
				activeShipsDt = DataBaseHandler.getActiveShips();

				shipRepeater.DataSource = activeShipsDt;
				shipRepeater.DataBind();

				DataTable inActiveShipsDT = DataBaseHandler.getInActiveShips();
				List<Vessel> shipList = new List<Vessel>();
				foreach (DataRow ship in inActiveShipsDT.Rows)
				{
					Vessel v = new Vessel();
					v.imo = ship["imoNumber"].ToString();
					v.name = ship["name"].ToString();
					shipList.Add(v);
				}
				addShipDropDown.DataSource = shipList;
				addShipDropDown.DataTextField = "name";
				addShipDropDown.DataValueField = "imo";

				addShipDropDown.DataBind();
			}

		}

		protected void addNewShip(object sender, EventArgs e)
		{
			DataBaseHandler.activateShip(addShipDropDown.SelectedItem.Value);

			DataTable activeShipsDt = new DataTable();
			activeShipsDt = DataBaseHandler.getActiveShips();
			shipRepeater.DataSource = activeShipsDt;
			shipRepeater.DataBind();
		}

		protected void commentChanged(object sender, EventArgs e)
		{
			TextBox tb = ((TextBox)sender);
			string comment = tb.Text;

			Console.WriteLine(comment);

			string imo = ((Literal)tb.Parent.FindControl("imo")).Text;

			Console.WriteLine(imo);

			DataBaseHandler.editComment(comment, imo);

			tb.Text = comment;


		}


	}
}
