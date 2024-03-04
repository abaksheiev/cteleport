using CTeleport.WebApi.Services.DTOs;

namespace CTeleport.WebApi.Services
{
    public interface IAirportService
    {
        /// <summary>
        /// Return distance between two airoports
        /// </summary>
        /// <param name="airportFrom">The code of the first airoport</param>
        /// <param name="airportTo">The code of the second airoport</param>
        /// <returns></returns>
        public Task<MeasuredDistanceDTO> GetAirportDistance(string airportFrom, string airportTo);
    }
}
