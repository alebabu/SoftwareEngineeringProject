using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;


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


            //      Now we make the connection.
            /*MySqlConnection con = new MySqlConnection();
			con.ConnectionString = connectionString;

            //      The Open method works!
            //      And the Open method fails correctly when wrong credentials are used.
            con.Open();

			string sql = "SELECT name FROM tbl_ship WHERE imoNumber=123";
			MySqlCommand cmd = new MySqlCommand(sql, con);
			cmd.Connection = con;
            sda.SelectCommand = cmd;
			sda.Fill(dt);
			MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
				name = (string) rdr[0];
            }

            rdr.Close();


            con.Close();*/

			
		}
	}
}
