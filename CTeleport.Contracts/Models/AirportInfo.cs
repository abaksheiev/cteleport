using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CTeleport.Contracts.Models
{
    [DataContract]
    public class AirportInfo
    {
        /// <summary>
        ///  International Air Transport Association
        /// </summary>
        public string Iata { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        /// <summary>
        /// International Civil Aviation Organization
        /// </summary>
        public string Icao { get; set; }

        public string Country { get; set; }

        public string CountryIata { get; set; }

        public LocationInfo Location { get;set;}

        public int Rating { get; set; }

        public int Hube { get; set; }

        public string TimezoneRegionName { get; set; }

        public string Type { get; set; }
        public class LocationInfo {
            
            [JsonPropertyName("Lon")]
            public double Longitude { get; set; }

            [JsonPropertyName("Lat")]
            public double Latitude { get; set; }
        
        }
    }
}
