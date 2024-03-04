using CTeleport.WebApi.Controllers;
using CTeleport.WebApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CTeleport.Contracts.Enums;
using CTeleport.WebApi.ApiModels;
using CTeleport.WebApi.Services.DTOs;

namespace CTeleport.Test
{
   
    public class MeasurementControllerTests
    {
        private MeasurementController _controller;
        private readonly Mock<IAirportService> _airportService;

        public MeasurementControllerTests()
        {
            _airportService = new Mock<IAirportService>();
        }

        [Theory]
        [InlineData("A", "B")]
        public async Task WhenGetDistance_ShouldBeReturnCorrectModel(string airPortFrom, string airPortTo)
        {
            var measuredDistanceResult = new MeasuredDistanceDTO
            {
                AirportTo = airPortFrom,
                AirportFrom = airPortTo,
                Length = It.IsAny<double>(),
                Measurement = MeasurementUnits.StatuteMile
            };

            _airportService.Setup(service => service
            .GetAirportDistance(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(measuredDistanceResult));


            _controller = new MeasurementController(_airportService.Object);

            var controllerResult = await _controller.GetDistance(airPortFrom, airPortTo) as OkObjectResult;

            var dataResult = (DistanceAirports)controllerResult.Value;

            dataResult.AirportFrom.Should().Be(measuredDistanceResult.AirportFrom);
            dataResult.AirportTo.Should().Be(measuredDistanceResult.AirportTo);
            dataResult.Length.Should().Be(measuredDistanceResult.Length);
            dataResult.Measurement.Should().Be($"{measuredDistanceResult.Measurement}");

        }
    }
}
