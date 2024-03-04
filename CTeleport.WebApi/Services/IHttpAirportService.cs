using CTeleport.Contracts.Models;

namespace CTeleport.WebApi.Services
{
    /// <summary>
    /// The APIAccessor class is designed to facilitate communication with an external API in order to retrieve Airport information.
    /// </summary>
    public interface IHttpAirportService
    {
        /// <summary>
        /// Return information of Airoport
        /// </summary>
        /// <param name="aeroportCode">Airport three letter' code</param>
        /// <returns>Instance of object</returns>
        public Task<AirportInfo> GetAiroportInfo(string aeroportCode);

        /// <summary>
        /// Check if Airport code valid
        /// </summary>
        /// <param name="aeroportCode">Airport three letter' code</param>
        /// <returns>Return true if Airport code valid</returns>
        public bool IsAirportValid(string aeroportCode);
    }
}
