using CTeleport.Contracts.Enums;

namespace CTeleport.Contracts.Configurations
{
    public class AirportServiceConfig
    {
        public static string SectionName = "AirportService";

        public AirportServiceConfig() { }

        public MeasurementUnits MeasurementUnit { get; set; }
        
    }
}
