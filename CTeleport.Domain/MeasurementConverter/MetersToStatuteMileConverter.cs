using CTeleport.Contracts.Enums;

namespace CTeleport.Domain.MeasurementConverter
{
    internal class MetersToStatuteMileConverter : IMeasurementConverter
    {
        private readonly double MetersInNauticalMile = 1609;

        public MeasurementUnits Unit => MeasurementUnits.StatuteMile;

        public double Convert(double value)
        {
            return value / MetersInNauticalMile; 
        }
    }
}
