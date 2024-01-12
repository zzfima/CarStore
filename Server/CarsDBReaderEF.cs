using Server.Models;
//from here: https://www.c-sharpcorner.com/article/get-started-with-entity-framework-core-using-sqlite/

namespace Server
{
    public class CarsDBReaderEF : ICarsDBReader
    {
        public List<Manufacturer> ReadManufacturers()
        {
            using (var db = new CarsStoreContext())
            {
                return db.Manufacturers.ToList();
            }
        }

        public List<BodyType> ReadBodyTypes()
        {
            using (var db = new CarsStoreContext())
            {
                return db.BodyTypes.ToList();
            }
        }

        public List<Sample> ReadSamples(BodyType bodyType, Manufacturer manufacturer)
        {
            using (var db = new CarsStoreContext())
            {
                return (from s in db.Samples
                        where s.Manufacturer == manufacturer
                        where s.BodyType == bodyType
                        select s).ToList();
            }
        }

        public void WriteOrder(Sample selectedSample)
        {
            using (var db = new CarsStoreContext())
            {
                db.Orders.Add(new Order() { SampleId = selectedSample.Id });
                db.SaveChanges();
            }
        }

        public Sample? ReadSample(int id)
        {
            using (var db = new CarsStoreContext())
            {
                return (from s in db.Samples
                        where s.Id == id
                        select s)?.FirstOrDefault();
            }
        }
    }
}
