using Server.Model;

namespace Server
{
    public class CarsDBReaderEF : ICarsDBReader
    {
        public List<Manufacturer> ReadManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            return manufacturers;
        }

        public List<BodyType> ReadBodyTypes()
        {
            List<BodyType> bodyTypes = new List<BodyType>();

            return bodyTypes;
        }

        public List<Sample> ReadSamples(BodyType bodyType, Manufacturer manufacturer)
        {
            List<Sample> samples = new List<Sample>();

            return samples;
        }

        public void WriteOrder(Sample selectedSample)
        {

        }
    }
}
