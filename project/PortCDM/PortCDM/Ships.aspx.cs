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

			//      Note the spelling of keywords.
            string connectionString = 
                    @"server=datavetare.com;" +
                    @"uid=lexxarc_portcdm;" +
					@"password=runda@0@bordet;" +
                    @"database=lexxarc_portcdm;";

			con = new MySqlConnection(connectionString);
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship");
			sda = new MySqlDataAdapter();

			cmd.Connection = con;
            sda.SelectCommand = cmd;
			DataTable dt = new DataTable();
			sda.Fill(dt);

			shipRepeater.DataSource = dt;
			shipRepeater.DataBind();
			con.Close();
			
		}

		protected async void addNewShip(object sender, EventArgs e)
		{
		}

		protected void commentChanged(object sender, EventArgs e)
		{
			con.Open();
			TextBox tb = ((TextBox)sender);
			string comment = tb.Text;

			Console.WriteLine(comment);

			string imoNumber = ((Literal)tb.Parent.FindControl("imo")).Text;

			Console.WriteLine(imoNumber);

			MySqlCommand cmd = new MySqlCommand("UPDATE tbl_ship SET comment = '" + comment + "' WHERE imoNumber = " + imoNumber + ";");
			cmd.Connection = con;

			sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
			cmd.ExecuteNonQuery();
			tb.Text = comment;

			con.Close();

		}


	}
}
