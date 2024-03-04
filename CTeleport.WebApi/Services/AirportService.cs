using CTeleport.Contracts.Configurations;
using CTeleport.Contracts.Models;
using CTeleport.Domain.MeasurementConverter;
using CTeleport.Domain.Caching;
using Microsoft.Extensions.Options;
using System.Device.Location;
using System.Diagnostics.CodeAnalysis;
using CTeleport.WebApi.Services.DTOs;

namespace CTeleport.WebApi.Services
{
    public class AirportService : IAirportService
    {
        private readonly ICacheProvider memoryCache;

        private readonly IHttpAirportService httpAirportService;
        private readonly IMeasurementConverterFactory measurementConverterFactory;
        private IMeasurementConverter measurementConverter;

        public AirportService(
            [NotNull] IHttpAirportService httpAiroportService,
            [NotNull] IMeasurementConverterFactory measurementConverterFactory,
            [NotNull] ICacheProvider memoryCache,
            [NotNull] IOptions<AirportServiceConfig> airportServiceConfig)
        {

            this.httpAirportService = httpAiroportService;
            this.measurementConverterFactory = measurementConverterFactory;
            this.memoryCache = memoryCache;

            measurementConverter = this.measurementConverterFactory.GetConverter(airportServiceConfig.Value.MeasurementUnit);
        }

        public async Task<MeasuredDistanceDTO> GetAirportDistance(string airportFrom, string airportTo)
        {
            var errors = new List<string>();

            if (!httpAirportService.IsAirportValid(airportFrom))
            {
                errors.Add($"Name of airport '{airportFrom}' is not correct");
            }

            if (!httpAirportService.IsAirportValid(airportTo))
            {
                errors.Add($"Name of airport '{airportTo}' is not correct");
            }

            if (errors.Any())
            {
                return new MeasuredDistanceDTO()
                {
                    Errors = errors
                };
            }

            try
            {
                return await GetAirportDistanceInternal(airportFrom, airportTo);
            }
            catch (Exception ex)
            {
                return new MeasuredDistanceDTO()
                {
                    Errors = [ex.Message]
                };
            }
        }

        private async Task<MeasuredDistanceDTO> GetAirportDistanceInternal(string airportFrom, string airportTo)
        {
            var airportFromInfo = await GetAiroportInfo(airportFrom);
            var airportToInfo = await GetAiroportInfo(airportTo);

            var sCoord = new GeoCoordinate(airportFromInfo.Location.Latitude, airportFromInfo.Location.Longitude);
            var eCoord = new GeoCoordinate(airportToInfo.Location.Latitude, airportToInfo.Location.Longitude);

            var lengthInMeters = sCoord.GetDistanceTo(eCoord);

            return (new MeasuredDistanceDTO
            {
                AirportFrom = airportFrom,
                AirportTo = airportTo,
                Length = measurementConverter.Convert(lengthInMeters),
                Measurement = measurementConverter.Unit
            });
        }

        private async Task<AirportInfo> GetAiroportInfo(string code)
        {
            var info = memoryCache.Get<AirportInfo>(code);

            if (info == null)
            {
                info = await httpAirportService.GetAiroportInfo(code);
                memoryCache.Set(code, info);
            }

            return info;
        }
    }
}
