using CTeleport.Contracts.Enums;

namespace CTeleport.WebApi.Services.DTOs
{
    public class MeasuredDistanceDTO
    {
        public string AirportFrom { get; set; }

        public string AirportTo { get; set; }

        public double Length { get; set; }

        public MeasurementUnits Measurement { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public MeasuredDistanceDTO() { }
        public MeasuredDistanceDTO(string from, string to, double length, MeasurementUnits measurement)
        {
            AirportFrom = from;
            AirportTo = to;
            Length = length;
            Measurement = measurement;
        }
    }
}
