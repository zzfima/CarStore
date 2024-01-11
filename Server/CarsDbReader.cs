using Server.Model;
using System;
using System.Data.SQLite;

namespace Server
{
	public class CarsDbReader
	{
		public CarsDbReader() { }

		public List<Manufacturer> ReadManufacturers()
		{
			string cs = @"Data Source = .\DB\DBcars.db;Version=3;New=True;Compress=True;";
			using var connect = new SQLiteConnection(cs);
			connect.Open();

			using (SQLiteCommand fmd = connect.CreateCommand())
			{
				SQLiteCommand sqlComm = new SQLiteCommand("select * from Manufacturer", connect);
				SQLiteDataReader rdr = sqlComm.ExecuteReader();

				while (rdr.Read())
				{
					Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)}");
				}
			}

			//using var cmd = new SQLiteCommand(stm, con);
			//using SQLiteDataReader rdr = cmd.ExecuteReader();

			//while (rdr.Read())
			//{
			//	Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)}");
			//}

			return null;
		}
	}
}
