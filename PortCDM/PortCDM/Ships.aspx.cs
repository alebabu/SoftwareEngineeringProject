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
			
		}

		protected void commentChanged(object sender, EventArgs e)
		{
			string text = ((TextBox)sender).Text;
			Console.WriteLine(text);
		}


	}
}
