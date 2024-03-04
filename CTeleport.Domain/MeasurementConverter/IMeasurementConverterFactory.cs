using CTeleport.Contracts.Enums;

namespace CTeleport.Domain.MeasurementConverter
{
    public interface IMeasurementConverterFactory
    {
        public IMeasurementConverter GetConverter(MeasurementUnits unit);
    }
}
