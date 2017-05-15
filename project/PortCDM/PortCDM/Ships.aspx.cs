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
			DataBaseHandler.getAllShips().Wait();
			DataTable activeShipsDt = new DataTable();
			activeShipsDt = DataBaseHandler.getActiveShips();

			shipRepeater.DataSource = activeShipsDt;
			shipRepeater.DataBind();

			DataTable inactiveShipsDT = new DataTable();
			inactiveShipsDT = DataBaseHandler.getInActiveShips();

			List<string> shipImos = new List<string>();

			foreach(DataRow row in inactiveShipsDT.Rows)
			{
				shipImos.Add(row["imoNumber"].ToString());
			}

			addShipDropDown.DataSource = shipImos;
			addShipDropDown.DataBind();
		}

		protected void addNewShip(object sender, EventArgs e)
		{
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
