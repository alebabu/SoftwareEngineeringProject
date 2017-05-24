using System;
using System.Data;
using PortCDM_RestStructs;
using PortCDM_App_Code;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace PortCDM
{
	public partial class Ships : System.Web.UI.Page
	{
		private static List<Vessel> shipList = new List<Vessel>();
		private static List<string> shipImosNames = new List<string>();


		protected async void Page_Load(Object sender, EventArgs e)
		{
			if (!(this.IsPostBack))
			{
			    await DataBaseHandler.getAllShips();
				Console.WriteLine("page_load");
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

			Console.WriteLine("deactivateShip before setdatatables");
			setDataTables();

		}

		protected async void addNewShip(object sender, EventArgs e)
		{
			string imoAndName = Request.Form[addShipDropDown.UniqueID];
			string[] imoAndNameSplit = imoAndName.Split(' ');
			string addImo = imoAndNameSplit[0];
			if (shipImosNames.Exists(obj => obj == imoAndName))
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
				Console.WriteLine(v.name);
			}
			Console.WriteLine("addNewShip before setdatatables");
			setDataTables();
		}

		private void setDataTables()
		{
			DataTable activeShipsDt = new DataTable();
			activeShipsDt = DataBaseHandler.getActiveShips();
			shipRepeater.DataSource = activeShipsDt;
			shipRepeater.DataBind();

			shipImosNames.Clear();
			shipList.Clear();
			DataTable inActiveShipsDT = DataBaseHandler.getInActiveShips();

			foreach (DataRow ship in inActiveShipsDT.Rows)
			{
				shipImosNames.Add(ship["imoNumber"].ToString() + " " +  ship["name"]);
			}


			addShipDropDown.DataSource = shipImosNames;

			addShipDropDown.DataBind();
			Console.WriteLine("setdatatables done");

		}

		protected object newTime(object o)
		{
			String s = (String)o;
			Console.WriteLine(s);
			DateHandler dh = new DateHandler();
			DateTime time = dh.stringToDate(s);
			o = time.ToString("d MMM HH:mm");
			return o; 			
		}

	}
}