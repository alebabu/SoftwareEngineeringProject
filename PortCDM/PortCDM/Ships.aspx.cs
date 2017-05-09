using System;
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

            //      Now we make the connection.
            MySqlConnection mySqlConnection = new MySqlConnection();
			mySqlConnection.ConnectionString = connectionString;

            //      The Open method works!
            //      And the Open method fails correctly when wrong credentials are used.
            mySqlConnection.Open();

			string sql = "SELECT name FROM tbl_ship WHERE imoNumber=123";
			MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
			MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }
            rdr.Close();


            mySqlConnection.Close();
			
		}
	}
}
