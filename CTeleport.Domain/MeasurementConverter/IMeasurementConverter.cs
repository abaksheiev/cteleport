using CTeleport.Contracts.Enums;

namespace CTeleport.Domain.MeasurementConverter
{
    // Interface for measurement conversion
    public interface IMeasurementConverter
    {
        /// <summary>
        /// destination Measured Unit
        /// </summary>
        public MeasurementUnits Unit { get; }
        
        /// <summary>
        /// Calcultion from meters to destination untis
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double Convert(double value);
    }
}
