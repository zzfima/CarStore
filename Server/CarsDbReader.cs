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

		public List<BodyType> ReadBodyTypes()
		{
			string cs = @"Data Source = .\DB\CarsStore.db;Version=3;New=True;Compress=True;";
			using var connection = new SQLiteConnection(cs);
			connection.Open();

			List<BodyType> bodyTypes = new List<BodyType>();
			using (SQLiteCommand fmd = connection.CreateCommand())
			{
				SQLiteCommand sqlComm = new SQLiteCommand("select * from BodyType", connection);
				SQLiteDataReader rdr = sqlComm.ExecuteReader();

				while (rdr.Read())
				{
					bodyTypes.Add(new BodyType(rdr.GetString(1)));
				}
			}

			return bodyTypes;
		}

		public List<Sample> ReadSamples(BodyType bodyType, Manufacturer manufacturer)
		{
			string cs = @"Data Source = .\DB\CarsStore.db;Version=3;New=True;Compress=True;";
			using var connection = new SQLiteConnection(cs);
			connection.Open();

			List<Sample> samples = new List<Sample>();
			using (SQLiteCommand fmd = connection.CreateCommand())
			{
				var query = $"SELECT Sample.Name FROM Sample " +
					$"INNER JOIN Manufacturer ON Sample.ManufacturerID = Manufacturer.ID " +
					$"INNER JOIN BodyType ON Sample.BodyTypeID = BodyType.ID " +
					$"WHERE Manufacturer.Name = \"{manufacturer.Name}\" AND BodyType.Name = \"{bodyType.Name}\"";


				SQLiteCommand sqlComm = new SQLiteCommand(query, connection);
				SQLiteDataReader rdr = sqlComm.ExecuteReader();

				while (rdr.Read())
				{
					samples.Add(new Sample(bodyType, manufacturer, rdr.GetString(0)));
				}
			}

			return samples;
		}
	}
}
