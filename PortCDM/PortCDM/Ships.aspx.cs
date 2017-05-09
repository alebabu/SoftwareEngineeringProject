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


namespace PortCDM
{
	public partial class Ships : System.Web.UI.Page
	{


		protected void Page_Load(Object sender, EventArgs e)
		{

			//      Note the spelling of keywords.
            string connectionString = 
                    @"server=127.0.0.1;" +
                    @"uid=root;" +
                    @"database=portCDM_schema;";

			MySqlConnection con = new MySqlConnection(connectionString);
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship");
			MySqlDataAdapter sda = new MySqlDataAdapter();

			cmd.Connection = con;
            sda.SelectCommand = cmd;
			DataTable dt = new DataTable();
			sda.Fill(dt);

			shipRepeater.DataSource = dt;
			shipRepeater.DataBind();
			
		}

		protected async void addNewShip(object sender, EventArgs e)
		{
			//Console.WriteLine(addImoBox.Text);
			//List<PortCall> portCallList = await RestHandler.getPortCalls();
			List<Vessel> vesselList = await RestHandler.getVessel(addImoBox.Text);
			Console.WriteLine(vesselList[0].name);
		}


	}
}
