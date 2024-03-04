using CTeleport.Contracts.Configurations;
using CTeleport.Contracts.Models;
using CTeleport.Domain.Caching;
using CTeleport.Domain.MeasurementConverter;
using CTeleport.WebApi.Services;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace CTeleport.Test
{
    public class AirportServiceTests
    {
        private readonly Mock<IHttpAirportService> httpAirportService;
        private readonly Mock<IMeasurementConverterFactory> measurementConverterFactory;
        private readonly Mock<IOptions<AirportServiceConfig>> airportServiceConfig;

        private readonly ICacheProvider cacheProvider;

        public AirportServiceTests()
        {
            httpAirportService = new Mock<IHttpAirportService>();
            measurementConverterFactory = new Mock<IMeasurementConverterFactory>();
            airportServiceConfig = new Mock<IOptions<AirportServiceConfig>>();

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            cacheProvider = new CacheMemoryProvider(memoryCache);
        }

        [Fact]
        public async Task WhenAirportCodeNotValid_ThanReturnErrors()
        {
            httpAirportService.Setup(service => service
            .IsAirportValid(It.IsAny<string>()))
            .Returns(false);

            airportServiceConfig.Setup(_ => _.Value).Returns(new AirportServiceConfig { MeasurementUnit = Contracts.Enums.MeasurementUnits.StatuteMile });

            var airportService = new AirportService(
                 httpAirportService.Object,
                 measurementConverterFactory.Object,
                 cacheProvider,
                 airportServiceConfig.Object
                );

            var result = await airportService.GetAirportDistance(It.IsAny<string>(), It.IsAny<string>());

            result.Errors.Count.Should().Be(2); 
        }

        [Theory]
        [InlineData("A", "A", 1)]  
        [InlineData("A", "B", 2)]
        public async Task WhenGetAiroportInfo_ShouldNotCallForTheSameCodes(string airPortFrom, string airPortTo, int numberCachCalls)
        {
            httpAirportService.Setup(service => service
               .IsAirportValid(It.IsAny<string>()))
               .Returns(true);

            httpAirportService
                .Setup(service => service.GetAiroportInfo(airPortFrom))
                .Returns(Task.FromResult(new AirportInfo()
                {
                    Iata = airPortFrom
                }));

            httpAirportService
               .Setup(service => service.GetAiroportInfo(airPortTo))
               .Returns(Task.FromResult(new AirportInfo()
               {
                   Iata = airPortTo
               }));

            airportServiceConfig.Setup(_ => _.Value).Returns(new AirportServiceConfig { MeasurementUnit = Contracts.Enums.MeasurementUnits.StatuteMile });

            var airportService = new AirportService(
                 httpAirportService.Object,
                 measurementConverterFactory.Object,
                 cacheProvider,
                 airportServiceConfig.Object
                );


            await airportService.GetAirportDistance(airPortFrom, airPortTo);

            httpAirportService.Verify(x => x.GetAiroportInfo(It.IsAny<string>()), Times.Exactly(numberCachCalls));
        }
    }
}
