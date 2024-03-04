using CTeleport.Contracts.Configurations;
using CTeleport.Contracts.Models;
using CTeleport.WebApi.Utils.Exceptions;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace CTeleport.WebApi.Services
{
    public class HttpAiroportService : IHttpAirportService
    {
        private HttpClient webServiceUri;

        public HttpAiroportService([NotNull] IHttpClientFactory httpClientFactory, [NotNull] IOptions<PlacesDevConfig> placesDevSettings) {

            webServiceUri = httpClientFactory.CreateClient("placesDevHost");
            webServiceUri.BaseAddress = new Uri(placesDevSettings.Value.Host);
        }

        public async Task<AirportInfo> GetAiroportInfo(string airportCode)
        {
            try
            {
                return await webServiceUri.GetFromJsonAsync<AirportInfo>($"/airports/{airportCode}");
            }
            catch (Exception ex)
            {
                throw new PlacesDevNotAvailableException(ex.Message);
            }
        }

        public bool IsAirportValid(string airportCode)
        {
            // Implement validation if airport not valid
            return true;
        }
    }
}
