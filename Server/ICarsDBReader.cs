using Server.Models;

namespace Server
{
    public interface ICarsDBReader
    {
        List<BodyType> ReadBodyTypes();
        List<Manufacturer> ReadManufacturers();
        Sample? ReadSample(int id);
        List<Sample> ReadSamples(BodyType bodyType, Manufacturer manufacturer);
        void WriteOrder(Sample selectedSample);
    }
}