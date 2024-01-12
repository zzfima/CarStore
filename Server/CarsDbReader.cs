using Server.Model;
using System.Data.SQLite;
using System.Xml.Linq;

namespace Server
{
    public class CarsDBReader : ICarsDBReader
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

                while (rdr?.Read() ?? false)
                    manufacturers.Add(new Manufacturer(rdr?.GetValue(1)?.ToString() ?? String.Empty));
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

                while (rdr?.Read() ?? false)
                    bodyTypes.Add(new BodyType(rdr?.GetValue(1)?.ToString() ?? String.Empty));
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
                var query = $@"
					SELECT Sample.Name FROM Sample 
					INNER JOIN Manufacturer ON Sample.ManufacturerID = Manufacturer.ID
					INNER JOIN BodyType ON Sample.BodyTypeID = BodyType.ID
					WHERE Manufacturer.Name = '{manufacturer.Name}' AND BodyType.Name = '{bodyType.Name}'";


                SQLiteCommand sqlComm = new SQLiteCommand(query, connection);
                SQLiteDataReader rdr = sqlComm.ExecuteReader();

                while (rdr?.Read() ?? false)
                    samples.Add(new Sample(bodyType, manufacturer, rdr?.GetValue(0)?.ToString() ?? String.Empty));
            }

            return samples;
        }

        public void WriteOrder(Sample selectedSample)
        {
            string cs = @"Data Source = .\DB\CarsStore.db;Version=3;New=True;Compress=True;";
            using var connection = new SQLiteConnection(cs);
            connection.Open();

            List<BodyType> bodyTypes = new List<BodyType>();
            using (SQLiteCommand fmd = connection.CreateCommand())
            {
                var query = $@"
					SELECT Sample.ID, Sample.Name FROM Sample 
					WHERE Name = '{selectedSample.Name}'";

                SQLiteCommand sqlComm = new SQLiteCommand(query, connection);
                SQLiteDataReader rdr = sqlComm.ExecuteReader();
                string id = string.Empty;
                while (rdr?.Read() ?? false)
                    id = rdr?.GetValue(0)?.ToString();

                sqlComm = new SQLiteCommand($"INSERT INTO \"Order\" (Sample_ID) VALUES({id});", connection);
                var res = sqlComm.ExecuteNonQuery();
            }
        }
    }
}
