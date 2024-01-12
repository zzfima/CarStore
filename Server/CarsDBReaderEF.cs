using Server.Model;
using Server.Models;
//from here: https://www.c-sharpcorner.com/article/get-started-with-entity-framework-core-using-sqlite/

namespace Server
{
    public class CarsDBReaderEF : ICarsDBReader
    {
        public List<ManufacturerRecord> ReadManufacturers()
        {
            List<ManufacturerRecord> manufacturers = new List<ManufacturerRecord>();
            using (var db = new CarsStoreContext())
            {
                //db.Items.Add(item);
                db.SaveChanges();
            }
            return manufacturers;
        }

        public List<BodyTypeRecord> ReadBodyTypes()
        {
            List<BodyTypeRecord> bodyTypes = new List<BodyTypeRecord>();

            return bodyTypes;
        }

        public List<SampleRecord> ReadSamples(BodyTypeRecord bodyType, ManufacturerRecord manufacturer)
        {
            List<SampleRecord> samples = new List<SampleRecord>();

            return samples;
        }

        public void WriteOrder(SampleRecord selectedSample)
        {

        }
    }
}
