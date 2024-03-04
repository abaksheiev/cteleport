using CTeleport.Contracts.Enums;

namespace CTeleport.Domain.MeasurementConverter
{
    internal class MetersToNauticalMileConventer: IMeasurementConverter
    {
        private readonly double MetersInNauticalMile = 1853;

        public MeasurementUnits Unit => MeasurementUnits.NauticalMile;

        public double Convert(double value)
        {
            return value / MetersInNauticalMile; 
        }
    }
}
