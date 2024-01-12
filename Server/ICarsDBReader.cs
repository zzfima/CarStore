using Server.Model;

namespace Server
{
    public interface ICarsDBReader
    {
        List<BodyTypeRecord> ReadBodyTypes();
        List<ManufacturerRecord> ReadManufacturers();
        List<SampleRecord> ReadSamples(BodyTypeRecord bodyType, ManufacturerRecord manufacturer);
        void WriteOrder(SampleRecord selectedSample);
    }
}