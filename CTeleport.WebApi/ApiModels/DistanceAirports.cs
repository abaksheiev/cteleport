using CTeleport.Contracts.Enums;

namespace CTeleport.WebApi.ApiModels
{
    public class DistanceAirports
    {
        public string AirportFrom { get; set; }

        public string AirportTo { get; set; }

        public double Length { get; set; }

        public string Measurement { get; set; }
    }
}
