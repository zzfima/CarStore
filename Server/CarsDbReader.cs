using Server.Model;
using System.Data.SQLite;

namespace Server
{
	public class CarsDbReader
	{
		public List<Manufacturer> ReadManufacturers()
		{
			string cs = @"Data Source = .\DB\CarsStore.db;Version=3;New=True;Compress=True;";
			using var connection = new SQLiteConnection(cs);
			connection.Open();

			List<Manufacturer> manufacturers = new List<Manufacturer>();
			using (SQLiteCommand fmd = connection.CreateCommand())
			{
				SQLiteCommand sqlComm = new SQLiteCommand("select * from Manufacturer", connection);
				SQLiteDataReader rdr = sqlComm.ExecuteReader();

				while (rdr.Read())
				{
					manufacturers.Add(new Manufacturer(rdr.GetString(1)));
				}
			}

			return manufacturers;
		}
	}
}
