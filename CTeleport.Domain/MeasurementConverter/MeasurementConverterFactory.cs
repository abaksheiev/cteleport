using CTeleport.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Domain.MeasurementConverter
{
    public class MeasurementConverterFactory: IMeasurementConverterFactory
    {
        public IMeasurementConverter GetConverter(MeasurementUnits unit)
        {
            switch (unit)
            {
                case MeasurementUnits.NauticalMile:
                    return new MetersToNauticalMileConventer();
                case MeasurementUnits.StatuteMile:
                    return new MetersToStatuteMileConverter();
                default:
                    throw new ArgumentException("Invalid unit specified.");
            }
        }
    }
}
