using System;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using PortCDM_App_Code;
using PortCDM_RestStructs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace PortCDM_App_Code
{
	public class DataBaseHandler
	{

		private static MySqlConnection conn;

		//Hosted database
		private const string connectionString =
			  @"server=datavetare.com;" +
			  @"uid=lexxarc_portcdm;" +
			  @"password=runda@0@bordet;" +
			  @"database=lexxarc_portcdm;";

		/*
        //Local database
        private const string connectionString =
            @"server=127.0.0.1;" +
            @"uid=root;" +
            @"database=portCDM;";*/

		public static DataTable getActiveShips()
		{
			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();
			}
			catch (MySqlException e)
			{
				Console.WriteLine(e.Message);
			}

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship WHERE active = '1'");
			MySqlDataAdapter sda = new MySqlDataAdapter();

			cmd.Connection = conn;
			sda.SelectCommand = cmd;

			DataTable dt = new DataTable();
			sda.Fill(dt);
			Console.WriteLine(dt);

			return dt;
		}



		public static DataTable getActiveShipWComments()
		{
			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();
			}
			catch (MySqlException e)
			{
				Console.WriteLine(e.Message);
			}

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship WHERE active = '1' AND comment IS NOT NULL ORDER BY arrivalDate ASC");
			MySqlDataAdapter sda = new MySqlDataAdapter();

			cmd.Connection = conn;
			sda.SelectCommand = cmd;

			DataTable dt = new DataTable();
			sda.Fill(dt);
			Console.WriteLine(dt);

			conn.Close();

			return dt;
		}



		public static DataTable getInActiveShips()
		{
			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();
			}
			catch (MySqlException e)
			{
				Console.WriteLine(e.Message);
			}

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship WHERE active = '0'");
			MySqlDataAdapter sda = new MySqlDataAdapter();

			cmd.Connection = conn;
			sda.SelectCommand = cmd;

			DataTable dt = new DataTable();
			sda.Fill(dt);
			Console.WriteLine(dt);

			return dt;
		}

		public static async Task<List<PortCall>> getAllShips()
		{
			List<PortCall> portCalls = await RestHandler.getPortCalls();

			foreach (PortCall p in portCalls)
			{
				string imo = p.vessel.imo;
				string name = p.vessel.name;
				string imgURL = p.vessel.photoURL;
				string portCallId = p.id;
				string arrivalDate = p.arrivalDate;
				Console.WriteLine(arrivalDate);

				conn = new MySqlConnection(connectionString);
				conn.Open();

				MySqlCommand cmd = new MySqlCommand("INSERT IGNORE INTO tbl_ship SET imoNumber = '" +
												   imo + "', name = '" + name + "', imgURL = '" +
													imgURL + "', portCallID = '" + portCallId +
				                                    "', active = '0', arrivalDate = '" + arrivalDate + "';");
				cmd.Connection = conn;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			return portCalls;
		}

		public static void activateShip(string imo)
		{
			conn = new MySqlConnection(connectionString);
			conn.Open();

			MySqlCommand cmd = new MySqlCommand("UPDATE tbl_ship SET active = '1' WHERE imoNumber = '" +
												imo + "';");
			cmd.Connection = conn;
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public static void deactivateShip(string imo)
		{
			conn = new MySqlConnection(connectionString);
			conn.Open();

			MySqlCommand cmd = new MySqlCommand("UPDATE tbl_ship SET active = '0' WHERE imoNumber = '" +
												imo + "';");
			cmd.Connection = conn;
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public static void editComment(string comment, string imo)
		{
			conn = new MySqlConnection(connectionString);
			MySqlCommand cmd = new MySqlCommand("UPDATE tbl_ship SET comment = '" + comment + "' WHERE imoNumber = " +
												imo + ";");

			conn.Open();
			cmd.Connection = conn;
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public static void addShip(string imo, string portCallId)
		{
		conn = new MySqlConnection(connectionString);
		MySqlCommand cmd = new MySqlCommand("INSERT IGNORE INTO tbl_ship SET imoNumber = '" +
											   imo + "', portCallID = '" + portCallId +
												"', active = '1';");

		conn.Open();
		cmd.Connection = conn;
		cmd.ExecuteNonQuery();
		conn.Close();

		}

		public static void addShip(Vessel v, string portCallId)
		{

			string[] tempimo = v.imo.Split(':');
			int imo = int.Parse(tempimo[tempimo.Length - 1]);
			conn = new MySqlConnection(connectionString);
			MySqlCommand cmd = new MySqlCommand("INSERT IGNORE INTO tbl_ship SET imoNumber = '" +
												imo + "', name = '" + v.name + "', imgURL = '" +
												v.photoURL + "', portCallID = '" + portCallId +
													"', active = '1';");

			conn.Open();
			cmd.Connection = conn;
			cmd.ExecuteNonQuery();
			conn.Close();
		}

<<<<<<< HEAD
		public static string getComment(string portCallId)
		{
			StringBuilder sb = new StringBuilder();
			conn = new MySqlConnection(connectionString);
			using (MySqlCommand cmd = new MySqlCommand("SELECT comment FROM tbl_ship WHERE portCallID = '" +
														   portCallId + "';", conn))
			{
				conn.Open();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						sb.Append(reader.GetString(0));
					}
				}
                conn.Close();
			}
			
			return sb.ToString();
		}

		public static string getPortCallId(string imo)
		{
			StringBuilder sb = new StringBuilder();
			conn = new MySqlConnection(connectionString);
			using (MySqlCommand cmd = new MySqlCommand("SELECT portCallID FROM tbl_ship WHERE imoNumber = '" +
														   imo + "';", conn))
			{
				conn.Open();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						sb.Append(reader.GetString(0));
					}
				}
                conn.Close();
			}
			
			return sb.ToString();
		}
=======

		public static DataTable getNextArrival()
		{
			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();
			}
			catch (MySqlException e)
			{
				Console.WriteLine(e.Message);
			}

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_ship WHERE active = '1' ORDER BY arrivalDate ASC LIMIT 3");
			MySqlDataAdapter sda = new MySqlDataAdapter();

			cmd.Connection = conn;
			sda.SelectCommand = cmd;

			DataTable dt = new DataTable();
			sda.Fill(dt);
			Console.WriteLine(dt.Rows[0]["name"]);

			conn.Close();

			return dt;
		}


>>>>>>> 2e674311cb6cf9bf05f976efaae211f0b1c186df
	}
}
