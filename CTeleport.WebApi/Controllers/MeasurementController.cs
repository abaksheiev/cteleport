using CTeleport.WebApi.ApiModels;
using CTeleport.WebApi.Models;
using CTeleport.WebApi.Services;
using CTeleport.WebApi.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CTeleport.WebApi.Controllers
{
    [Route("measurement")]
    public class MeasurementController : Controller
    {
        private IAirportService _airportService;

        public MeasurementController(IAirportService airportService)
        {
            _airportService = airportService;

        }

        [HttpGet("distance/{airportFrom}/{airportTo}")]
        public async Task<IActionResult> GetDistance(string airportFrom, string airportTo)
        {
            var airportDistanceResult = await _airportService.GetAirportDistance(airportFrom, airportTo);

            if (!airportDistanceResult.Errors.Any())
            {
                return Ok(new DistanceAirports
                {
                    AirportFrom = airportDistanceResult.AirportFrom,
                    AirportTo = airportDistanceResult.AirportTo,
                    Measurement = $"{airportDistanceResult.Measurement}",
                    Length = airportDistanceResult.Length
                });
            }
            else
            {
                return Ok(new GeneralErrors
                {
                    Errors = airportDistanceResult.Errors
                });
            }
        }
    }
}
